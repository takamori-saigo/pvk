namespace Services;

public static class HashPassword
{
    public static string MakeHash(string password) => password.Select(x => x - '0').Select(x => x*355).Sum().ToString();
}