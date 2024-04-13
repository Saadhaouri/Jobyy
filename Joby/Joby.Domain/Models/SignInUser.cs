using System.ComponentModel.DataAnnotations;

namespace Joby.Domain.Models
{
    public class SignInUser : User
    {
        [Required(ErrorMessage = "Username or email is required.")]
        public string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
