using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models
{
    public class AppUser : IdentityUser
    {
        public string? ProfilePic { get; set; }
        public string Fullname { get; set; } = null!;
        public string? Bio { get; set; }
        public string? Gender { get; set; }
        public bool IsPrivate { get; set; } = false;
        public bool İsBlock { get; set; } = false;
        public bool ActivtyStatusIsVisible { get; set; } = false;
        public List<Post>? Posts { get; set; }
        public List<Following>? Followings { get; set; }
        public List<Follower>? Followers { get; set; }
        [NotMapped]
        public List<MyDirect>? Directs { get; set; }

        //public List<Story>? Stories { get; set; }


        [NotMapped]
        public List<Saved>? Saveds { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }

        //[NotMapped]
        //public string RepeatPassword { get; set; } = null!;
    }
}
