using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM.Models
{
    [Index(nameof(VIN), IsUnique = true)]
    //[DefaultBindingProperty(nameof(Status))]
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Make { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Range(1, double.MaxValue)]
        [Required]
        [Precision(12,2)]
        public decimal Price { get; set; }
        [MaxLength(50)]
        public string? Color { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public int Mileage { get; set; }
        [Required]
        [MaxLength(17)]
        public string VIN { get; set; }
        [MaxLength(17)]
        public string? FuelType { get; set; }
        [MaxLength(17)]
        public string? Transmission { get; set; }
        [Required]
        [DefaultValue("Available")]
        public string Status { get; set; }


        public Sale Sale { get; set; }


        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
