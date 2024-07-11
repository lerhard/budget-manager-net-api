using BudgetManager.Domain.Entities;
using BudgetManager.Infrastructure.Data.Mappings.User;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Infrastructure.Data.Contexts.Users;

public class UserContext : BaseDbContext
{
    protected UserContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserBudget> UserBudgets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new UserMap())
            .ApplyConfiguration(new UserBudgetMap())
            .ApplyConfiguration(new UserGroupMap());
    }
}