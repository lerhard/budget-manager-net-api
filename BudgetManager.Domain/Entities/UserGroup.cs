using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManager.Domain.Entities;

[Table("usergroups")]
public class UserGroup
{
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("snowflake_id")]
        public long SnowflakeId { get; set; }
        
        [Column("user_id")]
        public int UserId { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [Column("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [Column("enabled")]
        public bool Enabled { get; set; }
        
        public User User { get; set; }
}