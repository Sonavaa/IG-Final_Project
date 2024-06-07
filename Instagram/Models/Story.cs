using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models
{
    public class Story : Audittable
    {
        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public string StoryUrl { get; set; } = null!;
        public bool IsVideo { get; set; } = default!;
        [NotMapped]
        public List<IFormFile>? File { get; set; }
    }
}
