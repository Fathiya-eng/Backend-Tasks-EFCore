using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Management_System.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int departmentId { get; set; } // System Generated

        [Required]
        [MaxLength(100)]
        public string departmentName { get; set; } // User Input

        [MaxLength(50)] // making ? because optional => if it is available
        public string? building { get; set; } // User Input

        [Required] // (>= 0) 
        [Range(0, double.MaxValue)]
        public decimal budget { get; set; } // User Input

        // Foreign Key => nullable (a department may have no head yet)
        [ForeignKey("HeadInstructor")]
        public int? headInstructorId { get; set; } // Foreign Key

        // Navigation Property (Department Head)
        public Instructor? HeadInstructor { get; set; }

        // Navigation Property (One Department has Many Courses)
        public ICollection<Course> Courses { get; set; }

    }
}
