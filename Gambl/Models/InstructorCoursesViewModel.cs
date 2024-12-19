using System.ComponentModel.DataAnnotations;

namespace Gambl.Models
{
    public class InstructorCoursesViewModel{
        [Key]
        public int InstructorsCoursesId{get;set;}
        public InstructorInfo? Instructor{get;set;}
        public List<CourseInfo>? Courses{get;set;}
    }
}