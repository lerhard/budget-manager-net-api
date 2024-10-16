using System.Data;

namespace BudgetManager.Domain.Interfaces.Infrastructure.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();
    IDbConnection GetConnection();
    IDbTransaction GetTransaction(); 
}