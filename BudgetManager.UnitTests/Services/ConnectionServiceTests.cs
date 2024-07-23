using System.Data;
using BudgetManager.Application.Services.Connection;
using BudgetManager.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace BudgetManager.UnitTests.Services;

public class ConnectionServiceTests
{
    [Fact]
    public void GetDefaultConnection_ShouldDecryptConnectionString()
    {
        // A
        var encryptionServiceMoq = new Mock<IEncryptionService>();
        encryptionServiceMoq.Setup(x => x
            .Decrypt(It.IsAny<string>()
                , It.IsAny<string>())).Returns("User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase");

        var configurationMoq = new Mock<IConfiguration>();
        configurationMoq.Setup(x => x.GetSection("DB_CONNECTION_STRING").Value).Returns("Test");
        
        var connectionService = new ConnectionService(encryptionServiceMoq.Object,configurationMoq.Object);

        var conn = connectionService.GetDefaultConnection();

         encryptionServiceMoq.Verify(x => x.Decrypt(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }
    
    [Fact]
    public void Connect_ShouldReturnIDbConnection_WithClosedConnectionState()
    {
        // Arrange
        var encryptionServiceMoq = new Mock<IEncryptionService>();
        encryptionServiceMoq.Setup(x => x
            .Decrypt(It.IsAny<string>()
                , It.IsAny<string>())).Returns("User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase");
        
        var configurationMoq = new Mock<IConfiguration>();
        configurationMoq.Setup(x => x.GetSection("DB_CONNECTION_STRING").Value).Returns("Test");
        var connectionService = new ConnectionService(encryptionServiceMoq.Object,configurationMoq.Object);

        // Act
        var conn = connectionService.GetDefaultConnection();

        // Assert
        Assert.Equal(ConnectionState.Closed, conn.State);
    }
}