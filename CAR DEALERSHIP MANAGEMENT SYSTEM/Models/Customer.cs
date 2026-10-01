using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(DriverLicenseNumber), IsUnique = true)]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(20)]
        public string DriverLicenseNumber { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale>();


        public CustomerProfile CustomerProfile { get; set; }
    }
}
