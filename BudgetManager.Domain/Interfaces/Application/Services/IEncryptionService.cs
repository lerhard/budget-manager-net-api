namespace BudgetManager.Domain.Interfaces.Application.Services;

public interface IEncryptionService
{
    string Encrypt(string plainText, string key = "");
    string Decrypt(string cipherText, string key = "");
}