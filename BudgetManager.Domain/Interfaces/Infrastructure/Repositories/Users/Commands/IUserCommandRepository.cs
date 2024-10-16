using System.Data;
using BudgetManager.Domain.Entities;

namespace BudgetManager.Domain.Interfaces.Repositories.Users.Commands;

public interface IUserCommandRepository
{
   Task<bool> AddAsync(User user, IDbConnection conn, IDbTransaction transaction = null);
   Task<bool> UpdateAsync(User user, IDbConnection conn, IDbTransaction transaction = null);
   Task<bool> DeleteAsync(User user, IDbConnection conn, IDbTransaction transaction = null);
}