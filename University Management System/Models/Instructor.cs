using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Management_System.Models
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int instructorId { get; set; } // System Generated

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } // User Input

        [Required]
        [MaxLength(150)]
        public string email { get; set; } // User Input

        [MaxLength(20)]
        public string? officeNumber { get; set; } // User Input

        [Required]
        public DateTime hireDate { get; set; } // User Input

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal salary { get; set; } // User Input

        [Required]
        [MaxLength(50)]
        public string academicTitle { get; set; } // User Input

        // Navigation Property (One Instructor teaches Many Courses) 1:M
        public ICollection<Course> courses { get; set; }  //= new List<Course>();

        // Navigation Property (Department Head)
        public Department? Department { get; set; }

    }
}
