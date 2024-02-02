namespace Testov.Models.Dto;

public class QuestionDto
{
    public Survey Survey { get; set; }
    public Question Question { get; set; } 
    public List<Answer> Answers { get; set; }
}