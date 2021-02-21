using FatecMauaJobNewsletter.Domains.Utils;
using System.ComponentModel.DataAnnotations;

namespace FatecMauaJobNewsletter.Domains.Models
{
    public class LoginRequest
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = ErrorMessages.IsRequired)]
        [MinLength(5, ErrorMessage = ErrorMessages.MinRequired)]
        [MaxLength(25, ErrorMessage = ErrorMessages.MaxRequired)]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = ErrorMessages.IsRequired)]
        [MinLength(10, ErrorMessage = ErrorMessages.MinRequired)]
        [MaxLength(40, ErrorMessage = ErrorMessages.MaxRequired)]
        public string Password { get; set; }
    }
}
