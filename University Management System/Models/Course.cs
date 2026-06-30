using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Management_System.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courseId { get; set; } // System Generated

        [Required]
        [MaxLength(10)]
        public string courseCode { get; set; } // User Input

        [Required]
        [MaxLength(150)]
        public string courseTitle { get; set; } // User Input

        [Required]
        [Range(1, 6)]
        public int creditHours { get; set; } // User Input

        [ForeignKey("Department")]
        public int departmentId { get; set; } // Foreign Key => not null

        [ForeignKey("Instructor")]
        public int? instructorId { get; set; } // Foreign Key => nullable (a course may be unassigned)

        [Required]
        [MaxLength(20)]
        public string semesterOffered { get; set; } // User Input

        // Navigation Property
        public Department Department { get; set; }

        // Navigation Property
        public Instructor? Instructor { get; set; }

        // Navigation Property
        public ICollection<Enrollment> Enrollments { get; set; } 

    }
}
