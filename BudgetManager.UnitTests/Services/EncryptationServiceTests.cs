using BudgetManager.Application.Encryption;

namespace BudgetManager.UnitTests.Services;

public class EncryptationServiceTests
{
    [Fact]
    public void Encrypt_WhenPlainTextIsValid_ReturnsEncryptedText()
    {
        // Arrange
        var encryptionService = new EncryptionService();
        var plainText = "BudgetManager";
        
        // Act
        var encryptedText = encryptionService.Encrypt(plainText);
        
        // Assert
        Assert.NotEqual(plainText, encryptedText);
    }
    
    [Fact]
    public void Encrypt_WhenPlainTextIsNullOrEmpty_ThrowsArgumentException()
    {
        // Arrange
        var encryptionService = new EncryptionService();
        
        // Act
        void Act() => encryptionService.Encrypt(string.Empty);
        
        // Assert
        Assert.Throws<ArgumentException>(Act);
    }
    
    [Fact]
    public void Decrypt_WhenCipherTextIsValid_ReturnsDecryptedText()
    {
        // Arrange
        var encryptionService = new EncryptionService();
        var plainText = "BudgetManager";
        var encryptedText = encryptionService.Encrypt(plainText);
        
        // Act
        var decryptedText = encryptionService.Decrypt(encryptedText);
        
        // Assert
        Assert.Equal(plainText, decryptedText);
    }
    
    [Fact]
    public void Decrypt_WhenCipherTextIsNullOrEmpty_ThrowsArgumentException()
    {
        // Arrange
        var encryptionService = new EncryptionService();
        
        // Act
        void Act() => encryptionService.Decrypt(string.Empty);
        
        // Assert
        Assert.Throws<ArgumentException>(Act);
    }
}