using BudgetManager.Application.Services.Connection;
using BudgetManager.Application.Services.Encryption;
using BudgetManager.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.Application;

public static class DependencyInjection
{
   public static void ConfigureApplication(this IServiceCollection services)
   {
      services.AddScoped<IEncryptionService, EncryptionService>();
      services.AddScoped<IConnectionService, ConnectionService>();
   } 
}