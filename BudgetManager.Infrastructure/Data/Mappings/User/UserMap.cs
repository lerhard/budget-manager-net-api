using BudgetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetManager.Infrastructure.Data.Mappings.User;

public class UserMap: IEntityTypeConfiguration<Domain.Entities.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(255);
        builder.Property(x => x.Surname).HasColumnName("surname").HasMaxLength(255);
        builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(255);
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
        builder.Property(x => x.Enabled).HasColumnName("enabled");
        builder.Property(x => x.Password).HasColumnName("password").HasMaxLength(72);
        builder.Property(x => x.Passcode).HasColumnName("passcode").HasMaxLength(6);
        builder.Property(x => x.SnowflakeId).HasColumnName("snowflake_id").ValueGeneratedOnAdd();

        builder.HasOne(x => x.UserGroup)
            .WithOne(x => x.User)
            .HasForeignKey<UserGroup>(ug => ug.UserId);
        
        builder.HasMany( x => x.UserBudgets)
            .WithOne(x => x.User)
            .HasForeignKey(ub => ub.UserId);
    }
}