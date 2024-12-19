using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Gambl.Models
{
    public class ContentInfo{
        [Key]
        public int ContentId { get; set; }
        public string? ContentName { get; set; }
    }
}