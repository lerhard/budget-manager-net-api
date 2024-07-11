using BudgetManager.Application;
using BudgetManager.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.Ioc;

public static class DependencyInjection
{
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
       services.ConfigureInfrastructure();
       services.ConfigureApplication();
    }
}