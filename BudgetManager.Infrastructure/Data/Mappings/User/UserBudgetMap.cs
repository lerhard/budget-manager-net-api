using BudgetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetManager.Infrastructure.Data.Mappings.User;

public class UserBudgetMap: IEntityTypeConfiguration<UserBudget>
{
    public void Configure(EntityTypeBuilder<UserBudget> builder)
    {
        builder.ToTable("user_budgets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.BudgetId).IsRequired();
    }
}