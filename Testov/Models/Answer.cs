namespace Testov.Models;

public class Answer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Questionid { get; set; }
    
    public Question? Question { get; set; }

}
