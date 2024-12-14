using System.ComponentModel.DataAnnotations;

namespace Gambl.Models{
    public class UserInfo{
        [Key]
        public int UserId {get;set;}
        public string? UserFN { get; set; }
        public string? UserLN { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public string? Password { get; set; }

    }

}

