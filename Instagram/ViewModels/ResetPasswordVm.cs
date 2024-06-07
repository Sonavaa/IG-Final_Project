using System.ComponentModel.DataAnnotations;

namespace Instagram.ViewModels
{
    public class ResetPasswordVm
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfrimPassword { get; set; }
    }
}
