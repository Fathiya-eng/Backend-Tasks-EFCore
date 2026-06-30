using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Management_System.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int enrollmentId { get; set; } // System Generated

        [ForeignKey("Student")]
        public int studentId { get; set; } // Foreign Key => not null 

        [ForeignKey("Course")]
        public int courseId { get; set; } // Foreign Key => not null 

        [Required]
        public DateTime enrollmentDate { get; set; } // User Input

        [MaxLength(2)]
        public string? finalGrade { get; set; } // User Input => optional 

        [Required]
        [MaxLength(20)]
        public string status { get; set; } = "In Progress"; // Default Value

        // Navigation Property
        public Student Student { get; set; }

        // Navigation Property
        public Course Course { get; set; }
    }
}
