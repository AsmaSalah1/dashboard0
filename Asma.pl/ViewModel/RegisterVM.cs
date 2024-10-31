using System.ComponentModel.DataAnnotations;

namespace Asmaa.Pl.ViewModel
{
    public class RegisterVM
    {
        //public string Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MinLength(3)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }
    }
}
