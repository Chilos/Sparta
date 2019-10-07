using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CryptoHelper;
using Microsoft.IdentityModel.Tokens;
using Sparta.Web.API.Services.Abstract;
using Sparta.Web.API.ViewModel;
using Sparta.Web.Model;

namespace Sparta.Web.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _jwtSecret;
        private readonly int _jwtLifespan;

        public AuthService(string jwtSecret, int jwtLifespan)
        {
            _jwtSecret = jwtSecret;
            _jwtLifespan = jwtLifespan;
        }

        public AuthData GetAuthData(User user)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(_jwtLifespan);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id),
                    new Claim(ClaimTypes.Role, user.Role), 

                }),
                Expires = expirationTime,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            
            return new AuthData
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                Role = user.Role,
                Id = user.Id,
                Username = user.Username
            };
        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
        }
    }
}