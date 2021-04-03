using FatecMauaJobNewsletter.Domains.Consts;
using System.ComponentModel.DataAnnotations;

namespace FatecMauaJobNewsletter.Domains.Models
{
    public class SignUpRequest
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

        [Display(Name = "Nome")]
        [Required(ErrorMessage = ErrorMessages.IsRequired)]
        [MinLength(3, ErrorMessage = ErrorMessages.MinRequired)]
        [MaxLength(60, ErrorMessage = ErrorMessages.MaxRequired)]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = ErrorMessages.IncorrectEmail)]
        public string Email { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = ErrorMessages.IncorrectPhoneNumber)]
        public string PhoneNumber { get; set; }  
    }
}
