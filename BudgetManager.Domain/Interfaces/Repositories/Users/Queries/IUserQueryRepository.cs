using System.Data;
using BudgetManager.Domain.Entities;

namespace BudgetManager.Domain.Interfaces.Repositories.Users.Queries;

public interface IUserQueryRepository
{
   Task<User> GetByIdAsync(Guid id,IDbConnection conn, IDbTransaction transaction = null);  
   Task<IEnumerable<User>> GetAllAsync(IDbConnection conn, IDbTransaction transaction = null);
}