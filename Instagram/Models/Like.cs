namespace Instagram.Models
{
    public class Like : Base
    {
        public string UserId { get; set; }
        public AppUser? User { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
