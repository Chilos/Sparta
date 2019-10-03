using System.ComponentModel.DataAnnotations;

namespace Sparta.Web.API.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
