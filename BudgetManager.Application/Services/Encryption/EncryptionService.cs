using System.Security.Cryptography;
using System.Text;
using BudgetManager.Domain.Interfaces.Application.Services;
using Aes = System.Security.Cryptography.Aes;

namespace BudgetManager.Application.Services.Encryption;

public class EncryptionService : IEncryptionService
{
    private readonly string defaultKey;
    private readonly string iv;

    public EncryptionService()
    {
       defaultKey = Environment.GetEnvironmentVariable("BM_DEFAULT_ENCRYPTION_KEY") ?? "BudgetManager";
       iv = "iv" + defaultKey;
    }

    public string Encrypt(string plainText, string key = "")
    {
        if (string.IsNullOrWhiteSpace(plainText))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(plainText));
        }

        key ??= defaultKey;


        using var aes = Aes.Create();
        aes.Key = GenerateKey(key);
        aes.IV = GenerateKey(iv, 16);

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }

                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    public string Decrypt(string cipherText, string key = "")
    {
        if (string.IsNullOrWhiteSpace(cipherText))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(cipherText));
        }

        key ??= defaultKey;
        var cipherBytes = Convert.FromBase64String(cipherText);

        using var aes = Aes.Create();
        aes.Key = GenerateKey(key);
        aes.IV = GenerateKey(iv,16);

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
        {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }

    private static byte[] GenerateKey(string key, int bytes = 32)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            Array.Resize(ref hash, bytes);
            return hash;
        }
    }
}