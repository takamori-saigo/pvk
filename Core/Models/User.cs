namespace Core;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string? Name { get; set; } = null;
    public string? Surname { get; set; } = null!; 
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }
    public Role? Role { get; set; } = null!;

    public int? GroupId { get; set; }
    public Group? Group { get; set; }

    public ICollection<Evaluation360> GivenEvaluations { get; set; } = new List<Evaluation360>();
    public ICollection<Evaluation360> ReceivedEvaluations { get; set; } = new List<Evaluation360>();
    
    public ICollection<BehaviorEvaluation> BehaviorEvaluationsAsManager { get; set; } = new List<BehaviorEvaluation>();
    public ICollection<BehaviorEvaluation> BehaviorEvaluationsAsIntern { get; set; } = new List<BehaviorEvaluation>();

    public ICollection<Task> CreatedTasks { get; set; } = new List<Task>();
    public ICollection<TaskEvaluation> TaskEvaluationsGiven { get; set; } = new List<TaskEvaluation>();
    public ICollection<TaskEvaluation> TaskEvaluationsReceived { get; set; } = new List<TaskEvaluation>();
}