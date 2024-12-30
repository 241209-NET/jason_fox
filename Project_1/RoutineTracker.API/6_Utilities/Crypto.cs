namespace RoutineTracker.API.Utilities;

public class Crypto
{
    public static string HashPassword(string password)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return System.Convert.ToBase64String(passwordHash);
    }

    public static bool ComparePasswords(string password, string passwordHash)
    {
        var passwordHashBytes = System.Convert.FromBase64String(passwordHash);
        using var hmac = new System.Security.Cryptography.HMACSHA512(passwordHashBytes);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != passwordHashBytes[i])
            {
                return false;
            }
        }
        return true;
    }
}