using Instagram.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.ViewModels.PostViewModel
{
    public class PostVm
    {
        public Post? Post { get; set; }
        public AppUser MyProfile { get; set; } = null!;
    }
}
