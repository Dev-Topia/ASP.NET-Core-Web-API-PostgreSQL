using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiWithPostgreSQL.Models
{
    [Table("Laptop")]
    public class Laptop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LaptopId { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public string? Year { get; set; }
        [Required]
        public string? Cpu { get; set; }
        [Required]
        public string? Vga { get; set; }
        [Required]
        public string? Ram { get; set; }
        [Required]
        public string? Storage { get; set; }
        [Required]
        public string? Screen { get; set; }
        [Required]
        public string? Connectivity { get; set; }
        [Required]
        public string? Os { get; set; }
        [Required]
        public string? Battery { get; set; }
        [Required]
        public string? Keyboard { get; set; }
        [Required]
        public string? Weight { get; set; }
        [Required]
        public double BuyInPrice { get; set; }
        [Required]
        public double SalePrice { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public double Offer { get; set; }
        [Required]
        public string? Warranty { get; set; }
    }
}