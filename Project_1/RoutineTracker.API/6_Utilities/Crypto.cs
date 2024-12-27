namespace RoutineTracker.API.Utilities;

public class Crypto
{
    public static string HashPassword(string password)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return System.Convert.ToBase64String(passwordHash);
    }
}