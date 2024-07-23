using System.Data;

namespace BudgetManager.Domain.Interfaces.Services;

public interface IConnectionService
{
    IDbConnection GetDefaultConnection();
}