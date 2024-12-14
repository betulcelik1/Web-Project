using System.ComponentModel.DataAnnotations;

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
        public List<LessonInfo> Lessons = new List<LessonInfo>();

    }

      public class LessonInfo
    {
        [Key]
        public int LessonId { get; set;}
        public string? LessonName { get; set; }
        public List<ContentInfo> content { get; set; } = new List<ContentInfo>();
    }

    public class ContentInfo
    {
        [Key]
        public int ContentId { get; set; }
        public string? ContentName { get; set; }
    }

    
}