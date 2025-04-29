namespace Core;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public int ManagerId { get; set; }
    public User Manager { get; set; } = null!;

    public ICollection<User> Interns { get; set; } = new List<User>();
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}
