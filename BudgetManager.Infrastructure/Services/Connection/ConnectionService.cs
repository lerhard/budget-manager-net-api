using System.Data;
using BudgetManager.Domain.Interfaces.Application.Services;
using BudgetManager.Domain.Interfaces.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BudgetManager.Infrastructure.Services.Connection;

public class ConnectionService : IConnectionService
{
    private readonly IEncryptionService _encryptionService;
    private readonly string _defaultConnectionString;

    public ConnectionService(IEncryptionService encryptionService, IConfiguration conf)
    {
        _encryptionService = encryptionService;
        if(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") == null)
        {
            Environment.SetEnvironmentVariable("DB_CONNECTION_STRING", conf.GetSection("DB_CONNECTION_STRING").Value);
        }
        
        if(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") == null)
        {
            throw new ArgumentNullException("DB_CONNECTION_STRING", "DB_CONNECTION_STRING is not set in environment variables or appsettings.json");
        }
        
        
        _defaultConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        
    }

    public IDbConnection GetDefaultConnection()
    {
        IDbConnection conn = PrepareConnection();
        return conn;
    }

        private NpgsqlConnection PrepareConnection()
    {
        if (string.IsNullOrWhiteSpace(_defaultConnectionString))
        {
            throw new ArgumentNullException("DB_CONNECTION_STRING", "DB_CONNECTION_STRING is not set in environment variables or appsettings.json");
        } 
        
        string decryptedConnection = _encryptionService.Decrypt(_defaultConnectionString);
        NpgsqlConnectionStringBuilder connectionBuilder = new NpgsqlConnectionStringBuilder(decryptedConnection);
        connectionBuilder.Timeout = 120;

        NpgsqlConnection conn = new NpgsqlConnection(connectionBuilder.ConnectionString);

        return conn;
    }
}