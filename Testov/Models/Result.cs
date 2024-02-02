namespace Testov.Models;

public class Result
{
    public int Id { get; set; }

    public int? Surveyid { get; set; }

    public int? Questionid { get; set; }

    public int? Answerid { get; set; }

    public string? Interviewsession { get; set; }

    public Answer? Answer { get; set; }

    public Question? Question { get; set; }

    public Survey? Survey { get; set; }
}
