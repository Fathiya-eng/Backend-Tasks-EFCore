using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Website_System.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; } // System Generated

        [Required]
        [MaxLength(150)]
        public string productName { get; set; } // User Input

        [MaxLength(1000)] //optional => ?
        public string? description { get; set; } // User Input

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 999999)]
        public decimal price { get; set; } // User Input

        [Required]
        [Range(0, int.MaxValue)]
        public int stockQuantity { get; set; } = 0; // Default Value

        [MaxLength(300)] //optional => ?
        public string? imageUrl { get; set; } // User Input

        [ForeignKey("productCategory")]
        public int categoryId { get; set; } // Foreign Key

        [Required]
        public DateTime createdAt { get; set; } = DateTime.Now; // System Generated

        public bool isAvailable { get; set; } = true; // Default Value

        // Navigation Property

        public virtual Category productCategory { get; set; }

        public virtual ICollection<Review> productReviews { get; set; } 

        public virtual ICollection<OrderProduct> orderProducts { get; set; } 

    }
}
