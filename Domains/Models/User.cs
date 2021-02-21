using FatecMauaJobNewsletter.Domains.Utils;
using System.ComponentModel.DataAnnotations;

namespace FatecMauaJobNewsletter.Domains.Models
{
    public class User : BaseEntity
    {
        public User
        (
            string login,
            string name,
            string email,
            UserType userType,
            string phoneNumber,
            string password
        )
        {
            Login = login;
            Name = name;
            Email = email;
            UserType = userType;
            PhoneNumber = phoneNumber;
            Password = HashUtil.HashPassword(password);
        }

        public User
        (
            string login,
            string name,
            string email,
            string phoneNumber,
            string password
        )
        {
            Login = login;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = HashUtil.HashPassword(password);
        }

        public User()
        {
        }

        [Display(Name = "Login")]
        [MinLength(5, ErrorMessage = ErrorMessages.MinRequired)]
        [MaxLength(25, ErrorMessage = ErrorMessages.MaxRequired)]
        public string Login { get; set; }

        [Display(Name = "Nome")]
        [MinLength(3, ErrorMessage = ErrorMessages.MinRequired)]
        [MaxLength(60, ErrorMessage = ErrorMessages.MaxRequired)]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = ErrorMessages.IncorrectEmail)]
        public string Email { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = ErrorMessages.IncorrectPhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public byte[] Password { get; set; }
    }
}
