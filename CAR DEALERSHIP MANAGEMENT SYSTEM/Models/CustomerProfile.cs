using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM.Models
{
    public class CustomerProfile
    {
        [Key]
        public int CustomerProfileId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(150)]
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
