using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sparta.Web.API.ViewModel
{
    public class UserViewModal
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string RealName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
