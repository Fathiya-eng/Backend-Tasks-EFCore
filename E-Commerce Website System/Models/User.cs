using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Website_System.Models
{
    public class User
    {
        [Key] // PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; } // System Generated

        [Required]
        [MaxLength(50)]
        public string username { get; set; } // User Input

        [Required]
        [MaxLength(150)]
        public string email { get; set; } // User Input

        [Required]
        [MaxLength(256)]
        public string passwordHash { get; set; } // User Input

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } // User Input

        [MaxLength(20)] //optional => ?
        public string? phoneNumber { get; set; } // User Input

        [MaxLength(300)] //optional => ?
        public string? address { get; set; } // User Input

        [Required]
        public DateTime registrationDate { get; set; } = DateTime.Now; // System Generated

        public bool isActive { get; set; } = true; // Default Value

        // Navigation Properties

        public virtual ICollection<Order> userOrders { get; set; } 

        public virtual ICollection<Review> userReviews { get; set; } 
    }
}
