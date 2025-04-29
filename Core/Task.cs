namespace Core;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;

    public int CreatedBy { get; set; }
    public User Creator { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<TaskEvaluation> Evaluations { get; set; } = new List<TaskEvaluation>();
}
