using System.Data;

namespace BudgetManager.Domain.Interfaces.Infrastructure.Services;

public interface IConnectionService
{
    IDbConnection GetDefaultConnection();
}