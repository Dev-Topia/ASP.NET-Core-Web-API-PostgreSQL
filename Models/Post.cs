using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiWithPostgreSQL.Models
{
    public class Post
    {
        [Key]
        [Column("post_id")]
        public int PostId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Required]
        [Column("content")]
        [MaxLength(4000)]
        public string? Content { get; set; }
        [Required]
        [Column("post_date")]
        public DateTime PostDate { get; set; }
    }
}