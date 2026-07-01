using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Website_System.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reviewId { get; set; } // System Generated

        [ForeignKey("reviewUser")]
        public int userId { get; set; } // Foreign Key

        [ForeignKey("reviewProduct")]
        public int productId { get; set; } // Foreign Key

        [Required]
        [Range(1, 5)]
        public int rating { get; set; } // User Input

        [MaxLength(1000)] // optional => ? 
        public string? comment { get; set; } // User Input

        [Required]
        public DateTime reviewDate { get; set; } = DateTime.Now; // System Generated

        // Navigation Properties

        public User reviewUser { get; set; }

        public Product reviewProduct { get; set; }
    }
}
