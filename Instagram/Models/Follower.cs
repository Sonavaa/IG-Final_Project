namespace Instagram.Models
{
    public class Follower : Base
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string UserFollowerId { get; set; }
        public AppUser UserFollower { get; set; }
    }
}
