namespace Core;

public class TaskEvaluation
{
    public int Id { get; set; }

    public int TaskId { get; set; }
    public Task Task { get; set; } = null!;

    public int InternId { get; set; }
    public User Intern { get; set; } = null!;

    public int ManagerId { get; set; }
    public User Manager { get; set; } = null!;

    public byte Grade { get; set; }
    public string? Feedback { get; set; }
    public DateTime EvaluatedAt { get; set; } = DateTime.Now;
}
