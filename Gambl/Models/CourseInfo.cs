using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gambl.Models
{
    public class CourseInfo
    {
        [Key]
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseCategory { get; set; }
        public string? CourseExplain { get; set; }
        public string? CourseInstructor { get; set; }
        public int CoursePay { get; set; }
        public byte[]? CourseImage { get; set; }
        public int? InstructorId { get; set; }
        
        
        [ForeignKey("InstructorId")]
        public InstructorInfo? Instructor { get; set; }
        

    }

     

    
}