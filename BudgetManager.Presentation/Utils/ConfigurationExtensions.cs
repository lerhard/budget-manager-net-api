namespace BudgetManager.Presentation.Utils;

public static class ConfigurationExtensions
{
    public static void PrepareDefaultEnvironmentVariables(this IConfiguration configuration)
    {
        var defaultEncryptionKey = Environment.GetEnvironmentVariable("BM_DEFAULT_ENCRYPTION_KEY");
        if (string.IsNullOrWhiteSpace(defaultEncryptionKey))
        {
            string defaultKey = configuration.GetSection("BM_DEFAULT_ENCRYPTION_KEY")?.Value;
            if(string.IsNullOrWhiteSpace(defaultKey))
            {
                throw new ArgumentNullException("BM_DEFAULT_ENCRYPTION_KEY", "BM_DEFAULT_ENCRYPTION_KEY is not set in environment variables or appsettings.json");
            }

            Environment.SetEnvironmentVariable("BM_DEFAULT_ENCRYPTION_KEY", defaultKey);
        }
        
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            string dbConnectionString = configuration.GetConnectionString("DefaultConnection");
            if(string.IsNullOrWhiteSpace(dbConnectionString))
            {
                throw new ArgumentNullException("DB_CONNECTION_STRING", "DB_CONNECTION_STRING is not set in environment variables or appsettings.json");
            }

            Environment.SetEnvironmentVariable("DB_CONNECTION_STRING", dbConnectionString);
        }
    }
}