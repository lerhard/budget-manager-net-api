using BudgetManager.Domain.Interfaces.Infrastructure.Services;
using BudgetManager.Domain.Interfaces.Infrastructure.UnitOfWork;
using BudgetManager.Domain.Interfaces.Repositories.Users;
using BudgetManager.Domain.Interfaces.Repositories.Users.Commands;
using BudgetManager.Domain.Interfaces.Repositories.Users.Queries;
using BudgetManager.Infrastructure.Data.Contexts.Budgets;
using BudgetManager.Infrastructure.Data.Contexts.Users;
using BudgetManager.Infrastructure.Data.Repositories.Users;
using BudgetManager.Infrastructure.Data.Repositories.Users.Commands;
using BudgetManager.Infrastructure.Data.Repositories.Users.Queries;
using BudgetManager.Infrastructure.Data.UnitOfWork;
using BudgetManager.Infrastructure.Services.Connection;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.Infrastructure;

public static class DependencyInjection
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        ConfigureUnitOfWork(services);
        ConfigureServices(services);
        ConfigureRepositories(services);
        ConfigureContexts(services);
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IConnectionService, ConnectionService>();
    }

    private static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserQueryRepository, UserQueryRepository>();
        services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void ConfigureContexts(this IServiceCollection services)
    {
        services.AddDbContext<UserContext>();
        services.AddDbContext<BudgetContext>();
    }

    private static void ConfigureUnitOfWork(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}