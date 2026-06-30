using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Management_System.Models
{
    public class Student
    {
        [Key] // Primary Key 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity column 
        public int studentId { get; set; } // System Generated

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } // User Input

        [Required]
        [MaxLength(150)]
        public string email { get; set; } // User Input

        [MaxLength(20)]
        public string? phoneNumber { get; set; } // User Input

        [Required]
        public DateTime dateOfBirth { get; set; } // User Input

        [Required]
        [Range(2000, 2030)]
        public int enrollmentYear { get; set; } // User Input

        [Column(TypeName = "decimal(3,2)")] // decimal(Precision (total no. of numbers), Scale(no. of mumbers after comma)) 
        [Range(0.0, 4.0)]
        public decimal gpa { get; set; } = 0.0m; // Default Value

        // Navigation Property (Student can Enroll many Courses)
        public ICollection<Enrollment> Enrollments { get; set; } 

    }
}

