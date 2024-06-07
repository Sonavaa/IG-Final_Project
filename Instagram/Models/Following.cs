namespace Instagram.Models
{
    public class Following : Base
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string UserFollowingId { get; set; }
        public AppUser UserFollowing { get; set; }

    }
}
