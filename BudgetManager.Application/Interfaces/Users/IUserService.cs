using BudgetManager.Application.DTOs.Users;

namespace BudgetManager.Application.Interfaces.Users;

public interface IUserService
{
    Task CreateUser(CreateUserDto user);
}