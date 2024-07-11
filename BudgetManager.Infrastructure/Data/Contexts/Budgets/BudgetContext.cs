using BudgetManager.Infrastructure.Data.Mappings.Budget;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Infrastructure.Data.Contexts.Budgets;

public class BudgetContext:BaseDbContext
{
    protected BudgetContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new BudgetMap())
            .ApplyConfiguration(new BudgetCostMap())
            .ApplyConfiguration(new BudgetIncomeMap());
    }
}