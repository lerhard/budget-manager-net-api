using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManager.Domain.Entities;

public class Budget
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("snowflake_id")]
    public long SnowflakeId { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("amount")]
    public decimal Amount { get; set; }
    
    [Column("currency")]
    public string Currency { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
    
    [Column("enabled")]
    public bool Enabled { get; set; }
    
    public IEnumerable<BudgetIncome> BudgetIncomes { get; set; }
    public IEnumerable<BudgetCost> BudgetCosts { get; set; }
    
}