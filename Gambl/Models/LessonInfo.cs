using System.ComponentModel.DataAnnotations;

namespace Gambl
{
    public class LessonInfo
    {
        [Key]
        public int LessonId { get; set;}
        public string? LessonName { get; set; }
        public List<ContentInfo> content { get; set; } = new List<ContentInfo>();
    }
}