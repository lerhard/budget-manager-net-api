using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BudgetManager.Domain.Entities.Enums;

namespace BudgetManager.Domain.Entities;

[Table("budget_costs")]
public class BudgetCost
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("snowflake_id")]
    public long SnowflakeId { get; set; }
    
    [Column("budget_id")]
    public int BudgetId { get; set; }
    
    [Column("amount")]
    public decimal Amount { get; set; }
    
    [Column("currency")]
    public string Currency { get; set; }
    
    [Column("entry_type")]
    public BudgetEntryType EntryType { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
    
    [Column("enabled")]
    public bool Enabled { get; set; } 
    
    public Budget Budget { get; set; }
}