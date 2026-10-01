using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM.Models
{
    [Index(nameof(Email), IsUnique = true)]

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(150)]
        public string Position { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }


        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}
