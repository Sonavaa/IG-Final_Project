using Instagram.Models;
using Instagram.ViewModels.HomeViewModel;
using Instagram.ViewModels.PostViewModel;

namespace Instagram.ViewModels.HomeViewModel
{
    public class HomeVm
    {
        public SuggestionsVm Users { get; set; }
        public SearchUserVm SearchUser { get; set; }
        public PostsVm Posts { get; set; }
        public AppUser MyProfile { get; set; }

    }
}
