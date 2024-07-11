using System.Data;
using BudgetManager.Domain.Entities;
using BudgetManager.Domain.Interfaces.Repositories.Users.Queries;
using Dapper;

namespace BudgetManager.Infrastructure.Data.Repositories.Users.Queries;

public partial class UserQueryRepository:IUserQueryRepository
{
    public async Task<User> GetByIdAsync(Guid id, IDbConnection conn, IDbTransaction transaction = null)
    {
        return await conn.QueryFirstOrDefaultAsync<User>(GET_USER_BY_ID, new { id },transaction);
    }

    public async Task<IEnumerable<User>> GetAllAsync(IDbConnection conn, IDbTransaction transaction = null)
    {
        return await conn.QueryAsync<User>(GET_ALL_USERS, transaction);
    }
}