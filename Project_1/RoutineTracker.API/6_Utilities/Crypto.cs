namespace RoutineTracker.API.Utilities;

public class Crypto
{
    public static string HashPassword(string password)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        var hashedPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedPassword);
    }

    public static bool ComparePasswords(string password, string hashedPassword)
    {
        var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
        using var hmac = new System.Security.Cryptography.HMACSHA512(hashedPasswordBytes);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != hashedPasswordBytes[i])
            {
                return false;
            }
        }
        return true;
    }
}