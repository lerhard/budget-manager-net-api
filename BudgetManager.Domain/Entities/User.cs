using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManager.Domain.Entities;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("snowflake_id")]
    public long SnowflakeId { get; set; }
    
    [Column("password")]
    [MaxLength(72)]
    public string Password { get; set; }
    
    [Column("passcode")]
    [MaxLength(6)]
    public string Passcode { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("name")]
    public string Name { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("surname")]
    public string Surname { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("email")]
    public string Email { get; set; }

    [Required]
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Required]
    [Column("enabled")]
    public bool Enabled { get; set; } 
    
    public UserGroup UserGroup { get; set; }
    
    public IEnumerable<UserBudget> UserBudgets { get; set; }
}