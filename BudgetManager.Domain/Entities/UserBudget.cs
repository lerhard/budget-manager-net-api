using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManager.Domain.Entities;

[Table("user_budgets")]
public class UserBudget
{
   [Key] 
   [Column("id")]
   public int Id { get; set; }
   
   [Column("user_id")]
   public int UserId { get; set; }
   
   [Column("budget_id")]
   public int BudgetId { get; set; }
   
   public User User { get; set; }
   
   public Budget Budget { get; set; }
}