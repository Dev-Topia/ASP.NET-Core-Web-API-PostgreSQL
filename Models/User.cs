using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTopiaStoreApi.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("username")]
        public string? Username { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }
    }
}