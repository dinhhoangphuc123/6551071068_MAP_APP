using System.Security.Cryptography;

namespace _6551071068_MAP_APP.Data;

internal static class PasswordHasher
{
    private const string Algorithm = "PBKDF2-SHA256";
    private const int CurrentIterations = 310_000;
    private const int MaximumAcceptedIterations = 1_000_000;
    private const int SaltSize = 16;
    private const int HashSize = 32;

    public static string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password, salt, CurrentIterations, HashAlgorithmName.SHA256, HashSize);
        return $"{Algorithm}${CurrentIterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }

    public static bool Verify(string storedPassword, string enteredPassword)
    {
        if (!storedPassword.StartsWith(Algorithm + "$", StringComparison.Ordinal))
        {
            return string.Equals(storedPassword, enteredPassword, StringComparison.Ordinal);
        }

        string[] parts = storedPassword.Split('$');
        if (parts.Length != 4 || parts[0] != Algorithm ||
            !int.TryParse(parts[1], out int iterations) || iterations is < 100_000 or > MaximumAcceptedIterations)
        {
            return false;
        }

        try
        {
            byte[] salt = Convert.FromBase64String(parts[2]);
            byte[] expectedHash = Convert.FromBase64String(parts[3]);
            if (salt.Length is < 8 or > 64 || expectedHash.Length is < 16 or > 64)
            {
                return false;
            }

            byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(
                enteredPassword, salt, iterations, HashAlgorithmName.SHA256, expectedHash.Length);
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool NeedsRehash(string storedPassword)
    {
        if (!storedPassword.StartsWith(Algorithm + "$", StringComparison.Ordinal))
        {
            return true;
        }

        string[] parts = storedPassword.Split('$');
        return parts.Length != 4 || !int.TryParse(parts[1], out int iterations) || iterations < CurrentIterations;
    }
}
