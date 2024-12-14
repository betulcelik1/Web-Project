using System.ComponentModel.DataAnnotations;

namespace Gambl.Models
{
    public class CourseBuy
    {
        [Key]
        public int CourseSignUpId { get; set; }
        public int CourseId{get;set;}
        public int UserId { get; set; }
        
       
    }
    
}