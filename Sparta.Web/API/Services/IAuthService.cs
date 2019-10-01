using Sparta.Web.API.ViewModel;

namespace Sparta.Web.API.Services
{
    public interface IAuthService
    {
        AuthData GetAuthData(string id, string role, string username);
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}
