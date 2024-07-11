using System.Data;
using BudgetManager.Domain.Entities;
using BudgetManager.Domain.Interfaces.Repositories.Users;
using BudgetManager.Domain.Interfaces.Repositories.Users.Commands;
using BudgetManager.Domain.Interfaces.Repositories.Users.Queries;
using BudgetManager.Infrastructure.Data.Contexts.Users;

namespace BudgetManager.Infrastructure.Data.Repositories.Users;

public class UserRepository:IUserRepository
{
    private readonly IUserCommandRepository _commandRepository;
    private readonly IUserQueryRepository _queryRepository;

    public UserRepository(IUserCommandRepository command, IUserQueryRepository queryRepository)
    {
        _commandRepository = command;
        _queryRepository = queryRepository;
    }

    public async Task<User> GetByIdAsync(Guid id, IDbConnection conn, IDbTransaction transaction = null)
    {
        return await _queryRepository.GetByIdAsync(id, conn, transaction);
    }

    public async Task<IEnumerable<User>> GetAllAsync(IDbConnection conn, IDbTransaction transaction = null)
    {
        
        return await _queryRepository.GetAllAsync(conn, transaction);
    }

    public async Task<bool> AddAsync(User user, IDbConnection conn, IDbTransaction transaction = null)
    {
        return await _commandRepository.AddAsync(user, conn, transaction);
    }

    public async Task<bool> UpdateAsync(User user, IDbConnection conn, IDbTransaction transaction = null)
    {
        return await _commandRepository.UpdateAsync(user, conn, transaction);
    }

    public async Task<bool> DeleteAsync(User user, IDbConnection conn, IDbTransaction transaction = null)
    {
        return await _commandRepository.DeleteAsync(user, conn, transaction);
    }
}