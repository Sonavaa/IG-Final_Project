using Instagram.Models;

namespace Instagram.ViewModels.HomeViewModel
{
    public class SuggestionsVm
    {
        public List<AppUser> Suggestions { get; set; }

        public AppUser MyProfile { get; set; }
    }
}
