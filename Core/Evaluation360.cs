namespace Core;

public class Evaluation360
{
    public int Id { get; set; }

    public int EvaluatorId { get; set; }
    public User Evaluator { get; set; } = null!;

    public int EvaluatedId { get; set; }
    public User Evaluated { get; set; } = null!;

    public byte Engagement { get; set; }
    public byte Organization { get; set; }
    public byte Learnability { get; set; }
    public byte Teamwork { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
