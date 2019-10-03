namespace Sparta.Web.API.ViewModel
{
    public class AuthData
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool NeedChangePassword { get; set; }
        public string Token { get; set; }
        public long TokenExpirationTime { get; set; }

    }
}
