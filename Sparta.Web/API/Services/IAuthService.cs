using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sparta.Web.API.ViewModel;

namespace Sparta.Web.API.Services
{
    public interface IAuthService
    {
        AuthData GetAuthData(string id);
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}
