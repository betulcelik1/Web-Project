using System.ComponentModel.DataAnnotations;

namespace Gambl.Models
{
    public class InstructorInfo{
        [Key]
        public int InstructorId { get; set; }
        public string? InstructorFN { get; set; }
        public string? InstructorLN { get; set; }
        public string? InstructorEmail { get; set; }
        public string? InstructorPhone { get; set; }
        public byte[]? InstructorImage { get; set; }
        public string? InstructorExplain { get; set; }

        public ICollection<CourseInfo>? Courses { get; set; }


    }
   
}