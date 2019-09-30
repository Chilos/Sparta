namespace Sparta.Web.API.ViewModel
{
    public class AuthData
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public long TokenExpirationTime { get; set; }
        public string Id { get; set; }
    }
}
