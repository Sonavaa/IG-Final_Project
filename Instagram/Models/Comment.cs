namespace Instagram.Models
{
    public class Comment : Base
    {
        public string Description { get; set; }
        public string UserId { get; set; }
        public AppUser? User { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
