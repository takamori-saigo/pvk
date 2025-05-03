using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Services;

public static class HashPassword
{
    // public static string MakeHash(string password) => password.Select(x => x - '0').Select(x => x*355).Sum().ToString();

    public static string? MakeHash(string password)
    {
        var inputBytes = Encoding.UTF8.GetBytes(password);
        var hashBytes = SHA256.HashData(inputBytes);
        return hashBytes.ToString();
    }
}