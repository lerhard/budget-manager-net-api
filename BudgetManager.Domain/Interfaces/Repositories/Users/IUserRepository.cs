using System.Data;
using BudgetManager.Domain.Entities;

namespace BudgetManager.Domain.Interfaces.Repositories.Users;

public interface IUserRepository
{
   Task<User> GetByIdAsync(Guid id, IDbConnection conn, IDbTransaction transaction = null);
   Task<IEnumerable<User>> GetAllAsync(IDbConnection conn, IDbTransaction transaction = null);
   
   Task<bool> AddAsync(User user, IDbConnection conn, IDbTransaction transaction = null);
   Task<bool> UpdateAsync(User user, IDbConnection conn, IDbTransaction transaction = null);
   Task<bool> DeleteAsync(User user, IDbConnection conn, IDbTransaction transaction = null);
}