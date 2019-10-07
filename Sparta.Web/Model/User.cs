using Sparta.Web.Model.Abstract;

namespace Sparta.Web.Model
{
    public class User : IEntityBase
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public bool NeedChangePassword { get; set; }
    }
}
