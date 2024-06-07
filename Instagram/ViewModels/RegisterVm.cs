using System.ComponentModel.DataAnnotations;

namespace Instagram.ViewModels
{
    public class RegisterVm
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Fullname is required.")]
        public string Fullname { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        //[DataType(DataType.Password),Compare(nameof(Password))]
        //public string ConfirmPassword { get; set; } = null!;
    }
}
