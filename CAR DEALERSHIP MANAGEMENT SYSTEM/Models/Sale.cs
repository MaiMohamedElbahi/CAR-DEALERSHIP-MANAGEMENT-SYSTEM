using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        [Precision(12,2)]
        [Range(0, double.MaxValue, ErrorMessage = "Sale price must be a positive value.")]
        public decimal SalePrice { get; set; }
        [Required]
        [MaxLength]
        public string PaymentMethod { get; set; }
        [MaxLength]
        public string? Notes { get; set; }



        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


        [ForeignKey("VehicleId")]
        public int VehicleId { get; set; }
    }
}
