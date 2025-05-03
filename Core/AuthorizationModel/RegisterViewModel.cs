namespace Core.AuthorizationModel;

public class RegisterViewModel
{
    public string Login { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public string Password { get; set; }
}