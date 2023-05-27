using System.Security.Cryptography;
using System.Text;

namespace Shared;

public static class Hash
{
    public static string Make(string rawString, string salt)
    {
        var saltBytes = Encoding.UTF8.GetBytes(salt);

        byte[] rawStringBytes = Encoding.UTF8.GetBytes(rawString);
        byte[] saltedRawStringBytes = new byte[saltBytes.Length + rawStringBytes.Length];
        Buffer.BlockCopy(saltBytes, 0, saltedRawStringBytes, 0, saltBytes.Length);
        Buffer.BlockCopy(rawStringBytes, 0, saltedRawStringBytes, saltBytes.Length, rawStringBytes.Length);

        byte[] hashBytes;
        using (var sha256 = SHA256.Create())
        {
            hashBytes = sha256.ComputeHash(saltedRawStringBytes);
        }

        byte[] hashBytesWithSalt = new byte[saltBytes.Length + hashBytes.Length];
        Buffer.BlockCopy(saltBytes, 0, hashBytesWithSalt, 0, saltBytes.Length);
        Buffer.BlockCopy(hashBytes, 0, hashBytesWithSalt, saltBytes.Length, hashBytes.Length);

        return Convert.ToBase64String(hashBytesWithSalt);
    }

    public static bool Verify(string rawString, string salt, string hash)
    {
        return Hash.Make(rawString, salt) == hash;
    }

    public static bool Verify(string hash1, string hash2)
    {
        return hash1 == hash2;
    }
}