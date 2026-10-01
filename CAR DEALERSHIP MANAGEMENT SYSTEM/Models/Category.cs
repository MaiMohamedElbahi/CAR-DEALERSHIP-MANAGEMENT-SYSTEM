using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }


        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
