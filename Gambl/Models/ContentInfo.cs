using System.ComponentModel.DataAnnotations;

namespace Gambl
{
    
    public class ContentInfo
    {
        [Key]
        public int ContentId { get; set; }
        public string? ContentName { get; set; }
    }
}