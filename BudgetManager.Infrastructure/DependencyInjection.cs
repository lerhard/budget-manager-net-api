using BudgetManager.Domain.Interfaces.Repositories.Users.Commands;
using BudgetManager.Domain.Interfaces.Repositories.Users.Queries;
using BudgetManager.Infrastructure.Data.Contexts.Budgets;
using BudgetManager.Infrastructure.Data.Contexts.Users;
using BudgetManager.Infrastructure.Data.Repositories.Users.Commands;
using BudgetManager.Infrastructure.Data.Repositories.Users.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.Infrastructure;

public static class DependencyInjection
{
   public static void ConfigureInfrastructure(this IServiceCollection services)
   {
       services.AddDbContext<UserContext>();
       services.AddDbContext<BudgetContext>();
       
       services.AddScoped<IUserQueryRepository, UserQueryRepository>();
       services.AddScoped<IUserCommandRepository, UserCommandRepository>();
   } 
}