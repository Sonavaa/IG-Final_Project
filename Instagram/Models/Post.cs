using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Instagram.Models
{
    public class Post : Audittable
    {
        public string? PostUrl { get; set; }
        public string? Caption { get; set; }
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        public bool IsReels { get; set; } = false; //MG ele

        [NotMapped]
        public IFormFile File { get; set; }
        public List<Like>? Likes { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Saved>? Saved { get; set; }
    }
}
