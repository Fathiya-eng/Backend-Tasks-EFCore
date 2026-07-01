using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Website_System.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; } // System Generated

        [ForeignKey("orderUser")]
        public int userId { get; set; } // Foreign Key

        [Required]
        public DateTime orderDate { get; set; } // System Generated

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 999999)]
        public decimal totalAmount { get; set; } // Calculated

        [Required]
        [MaxLength(30)]
        public string status { get; set; } = "Pending"; // Default Value

        [Required]
        [MaxLength(300)]
        public string shippingAddress { get; set; } // User Input

        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; } // From List

        // Navigation Property

        public User orderUser { get; set; }

        public ICollection<OrderProduct> orderProducts { get; set; } 

    }
}
