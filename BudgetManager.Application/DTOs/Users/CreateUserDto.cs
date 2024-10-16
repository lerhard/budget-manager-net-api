namespace BudgetManager.Application.DTOs.Users;

public record CreateUserDto(string Name, string Surname, string Email, string Password);