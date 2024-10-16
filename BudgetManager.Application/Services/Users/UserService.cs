using BudgetManager.Application.DTOs.Users;
using BudgetManager.Application.Interfaces.Users;
using BudgetManager.Domain.Interfaces.Infrastructure.UnitOfWork;

namespace BudgetManager.Application.Services.Users;

public class UserService:IUserService
{
    public UserService(IUnitOfWork unitOfWork)
    {
        
    }
    public Task CreateUser(CreateUserDto user)
    {
        throw new NotImplementedException();
    }
}