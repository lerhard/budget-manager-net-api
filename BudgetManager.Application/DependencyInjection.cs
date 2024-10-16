using BudgetManager.Application.Interfaces.Users;
using BudgetManager.Application.Services.Encryption;
using BudgetManager.Application.Services.Users;
using BudgetManager.Domain.Interfaces.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.Application;

public static class DependencyInjection
{
   public static void ConfigureApplication(this IServiceCollection services)
   {
       ConfigureServices(services);
   } 
   
   private static void ConfigureServices(this IServiceCollection services)
   {
       services.AddScoped<IEncryptionService, EncryptionService>();
       services.AddScoped<IUserService, UserService>();
   }
   
}