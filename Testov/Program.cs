using Microsoft.EntityFrameworkCore;
using Testov.Models;
using Testov.Models.Dto;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDbContext<PostgresContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/getQuestion/{surveyId}/{questionId?}", async (PostgresContext context, int surveyId, int? questionId) =>
{
    var survey = await context.Surveys.AsNoTracking().FirstOrDefaultAsync(x => x.Id == surveyId);

    if (survey == null)
        return Results.NotFound("Survey not found");

    Question question;

    IQueryable<Question> questions = context.Questions;

    try
    {
        if (questionId == null)
            question = await questions.AsNoTracking().FirstAsync(x => x.Surveyid == surveyId);
        else
            question = await questions.AsNoTracking().FirstAsync(x => x.Id == questionId);
    }
    catch
    {
        return Results.NotFound("Question not found");
    }

    IQueryable<Answer> answers = context.Answers.AsNoTracking().Where(x => x.Questionid == question.Id);
    var filteredAnswers = await answers.ToListAsync();

    QuestionDto questionDto = new()
    {
        Question = question,
        Survey = survey,
        Answers = filteredAnswers
    };

    return Results.Ok(questionDto);
});

app.MapPost("/saveAnswer/{interviewSession}/{answerId}", async (PostgresContext context, string interviewSession, int answerId) =>
{
    var answer = await context.Answers.AsNoTracking()
                                      .Include(x => x.Question)
                                      .ThenInclude(x => x.Survey)
                                      .FirstOrDefaultAsync(x => x.Id == answerId);
        
    Result result = new()
    {
        Answerid = answerId,
        Questionid = answer.Questionid,
        Surveyid = answer.Question.Surveyid,
        Interviewsession = interviewSession
    };

    try
    {   
        await context.Results.AddAsync(result);
        await context.SaveChangesAsync();
    }
    catch
    {
        return Results.BadRequest();
    }

    int maxQuestionId = await context.Questions.AsNoTracking()
                                                .Where(x => x.Surveyid == answer.Question.Surveyid)
                                                .MaxAsync(x => x.Id);

    if (maxQuestionId > answer.Questionid)
    {
        return Results.Ok(answer.Questionid + 1);
    }

    return Results.Ok("Test completed");
});

app.Run();