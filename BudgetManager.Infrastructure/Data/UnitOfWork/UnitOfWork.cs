using System.Data;
using BudgetManager.Domain.Interfaces.Infrastructure.Services;
using BudgetManager.Domain.Interfaces.Infrastructure.UnitOfWork;
using BudgetManager.Infrastructure.Data.Contexts;

namespace BudgetManager.Infrastructure.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly IConnectionService _connectionService;
    private IDbConnection? _connection;
    private IDbTransaction? _transaction;
    private bool _disposed;
    private bool _committed;
    private BaseDbContext? _context;

    public UnitOfWork(IConnectionService connectionService)
    {
        _connectionService = connectionService;
        _committed = false;
        _disposed = false;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void BeginTransaction()
    {
        _connection = GetConnection();
        _transaction = _connection.BeginTransaction();
        _context?.SetConnection(_connection);
        _context?.SetTransaction(_transaction);
    }

    public void Commit()
    {
        if (_transaction != null && !_committed)
        {
            _transaction.Commit();
            _committed = true;
        }
    }

    public void Rollback()
    {
        if (_transaction != null && !_committed)
        {
            _transaction.Rollback();
        }
    }

    public IDbConnection GetConnection()
    {
        _connection ??= _connectionService.GetDefaultConnection();
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }

        return _connection;
    }

    public IDbTransaction GetTransaction()
    {
        if (_transaction is null)
        {
            BeginTransaction();
        }
        
        return _transaction;
    }
    
    public void SetContext(BaseDbContext context)
    {
        _context = context;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            if (_transaction != null && !_committed)
            {
                _transaction.Rollback();
            }

            _transaction?.Dispose();
            _connection?.Dispose();
        }

        _disposed = true;
    }
}