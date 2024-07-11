using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetManager.Infrastructure.Data.Mappings.Budget;

public class BudgetMap:IEntityTypeConfiguration<Domain.Entities.Budget>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Budget> builder)
    {
        builder.ToTable("bugets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.SnowflakeId).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(255);
        builder.Property(x => x.Amount).HasColumnType("decimal(10,2)").IsRequired();
        
        builder.HasMany(x => x.BudgetCosts)
            .WithOne(x => x.Budget)
            .HasForeignKey(bc => bc.BudgetId);

        builder.HasMany(x => x.BudgetIncomes)
            .WithOne(x => x.Budget)
            .HasForeignKey(x => x.BudgetId);
    }
}