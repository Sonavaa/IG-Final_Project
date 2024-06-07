using Instagram.Models;

namespace Instagram.ViewModels.PostViewModel
{
    public class PostsVm
    {
        public List<Post>? Posts { get; set; }

        public AppUser MyProfile { get; set; } = null!;
    }
}
