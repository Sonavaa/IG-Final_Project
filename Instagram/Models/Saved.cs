namespace Instagram.Models
{
    public class Saved : Base
    {
        public string UserId { get; set; }
        public AppUser? User { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
