using BudgetManager.Application.Encryption;
using BudgetManager.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.Application;

public static class DependencyInjection
{
   public static void ConfigureApplication(this IServiceCollection services)
   {
      services.AddScoped<IEncryptionService, EncryptionService>();
   } 
}