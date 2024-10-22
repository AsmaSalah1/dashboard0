using System.ComponentModel.DataAnnotations;

namespace Asmaa.Pl.ViewModel
{
    public class ForgotPasswardVM
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
