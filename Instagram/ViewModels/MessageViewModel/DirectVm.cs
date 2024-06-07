using Instagram.Models;

namespace Instagram.ViewModels.MessageViewModel
{
    public class DirectVm
    {
        public AppUser MyProfile { get; set; }

        public List<MyDirect> MyDirects { get; set; }
    }
}
