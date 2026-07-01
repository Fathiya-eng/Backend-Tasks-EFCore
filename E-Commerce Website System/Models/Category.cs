using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Website_System.Models
{
    public class Category
    {
        [Key] //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryId { get; set; } // System Generated

        [Required]
        [MaxLength(100)]
        public string categoryName { get; set; } // User Input

        [MaxLength(500)] //optional => ?
        public string? description { get; set; } // User Input

        [MaxLength(300)] //optional => ?
        public string? imageUrl { get; set; } // User Input

        // Navigation Property

        public ICollection<Product> categoryProducts { get; set; } 
    }
}
