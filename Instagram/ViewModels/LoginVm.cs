using System.ComponentModel.DataAnnotations;

namespace Instagram.ViewModels
{
    public class LoginVm
    {
        public string Username { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
