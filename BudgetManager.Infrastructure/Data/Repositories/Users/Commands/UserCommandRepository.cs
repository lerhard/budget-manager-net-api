using System.Data;
using BudgetManager.Domain.Entities;
using BudgetManager.Domain.Interfaces.Repositories.Users.Commands;
using BudgetManager.Infrastructure.Data.Contexts.Users;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Infrastructure.Data.Repositories.Users.Commands;

public class UserCommandRepository : IUserCommandRepository
{
    private readonly UserContext _context;

    public UserCommandRepository(UserContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(User user, IDbConnection conn, IDbTransaction transaction = null)
    {
        ConfigureContext(conn,transaction);
        
        var result = await _context.Users.AddAsync(user);
        return result.State == EntityState.Added;
    }

    public async Task<bool> UpdateAsync(User user, IDbConnection conn, IDbTransaction transaction = null)
    {
        ConfigureContext(conn,transaction);

        var result = _context.Users.Update(user);
        return result.State == EntityState.Modified;

    }

    public async Task<bool> DeleteAsync(User user, IDbConnection conn, IDbTransaction transaction = null)
    {
        ConfigureContext(conn,transaction);
         var result = _context.Users.Remove(user);
         return result.State == EntityState.Deleted;
    }

    private void ConfigureContext(IDbConnection conn, IDbTransaction transaction = null)
    {
        _context.SetConnection(conn);
        if (transaction is not null)
        {
            _context.SetTransaction(transaction);
        }
    }
}