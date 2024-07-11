namespace BudgetManager.Infrastructure.Data.Repositories.Users.Queries;

public partial class UserQueryRepository
{
   private const string GET_USER_BY_ID = "SELECT * FROM Users WHERE id = @id"; 
   private const string GET_ALL_USERS = "SELECT * FROM Users";
}