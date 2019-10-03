using Sparta.Web.API.ViewModel;
using Sparta.Web.Model;

namespace Sparta.Web.API.Services.Abstract
{
    public interface IAuthService
    {
        AuthData GetAuthData(User user);
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}
