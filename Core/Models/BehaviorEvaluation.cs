namespace Core;

public class BehaviorEvaluation
{
    public int Id { get; set; }

    public int ManagerId { get; set; }
    public User Manager { get; set; } = null!;

    public int InternId { get; set; }
    public User Intern { get; set; } = null!;

    public byte RuleFollowing { get; set; }
    public byte Communication { get; set; }
    public byte TaskUnderstanding { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
