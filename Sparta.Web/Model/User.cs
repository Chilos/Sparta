namespace Sparta.Web.Model
{
    public class User : IEntityBase
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public int PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
