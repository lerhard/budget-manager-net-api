using BudgetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetManager.Infrastructure.Data.Mappings.Budget;

public class BudgetCostMap : IEntityTypeConfiguration<BudgetCost>
{
    public void Configure(EntityTypeBuilder<BudgetCost> builder)
    {
        builder.ToTable("budget_costs");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.SnowflakeId).ValueGeneratedOnAdd();
        builder.Property(x => x.Amount).HasColumnType("decimal(10,2)").IsRequired();
        builder.Property(x => x.Currency).HasMaxLength(3).IsRequired();
        builder.Property(x => x.EntryType).HasConversion<string>().IsRequired();


        builder.HasOne(x => x.Budget)
            .WithMany(x => x.BudgetCosts)
            .HasForeignKey(x => x.BudgetId);
    }
}