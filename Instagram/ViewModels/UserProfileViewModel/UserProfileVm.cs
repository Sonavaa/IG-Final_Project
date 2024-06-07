using Instagram.Models;

namespace Instagram.ViewModels.UserProfileViewModel
{
    public class UserProfileVm
    {
        public AppUser User { get; set; } = null!;
        public AppUser MyProfile { get; set; } = null!;
    }
}
