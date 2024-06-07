using Instagram.Models;

namespace Instagram.ViewModels.PostViewModel
{
    public class PostCreateVm
    {
        public string PostUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string? Caption { get; set; }

        public IFormFile File { get; set; }
        public Post Post { get; set; }
        public AppUser MyProfile { get; set; }
    }


    public class PostCreateVM
    {

        public string? Caption { get; set; }
        public string? Base64 { get; set; }

        public IFormFile? File { get; set; } 


    }
}
