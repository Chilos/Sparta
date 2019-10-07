using System;
using Microsoft.AspNetCore.Mvc;
using Sparta.Web.API.Services.Abstract;
using Sparta.Web.API.ViewModel;
using Sparta.Web.Data.Abstract;
using Sparta.Web.Model;

namespace Sparta.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult<AuthData> Post([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = _userRepository.GetSingle(u => u.Username == model.Username);
            if (user == null)
                return BadRequest(new {username = "no user with this name", error_code = "USER_NOT_FOUND"});

            var passwordValid = _authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid)
                return BadRequest(new {password = "invalid password", error_code = "INVALID_PASSWORD" });

            if (user.NeedChangePassword && string.IsNullOrEmpty(model.NewPassword))
                return BadRequest(new {password = "change password", error_code = "CHANGE_PASSWORD"});

            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                user.Password = _authService.HashPassword(model.NewPassword);
                user.NeedChangePassword = false;
                _userRepository.Update(user);
                _userRepository.Commit();
            }

            return _authService.GetAuthData(user);
        }

        [HttpPost("register")]
        public ActionResult<AuthData> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var phoneUniq = _userRepository.IsPhoneNumberUniq(model.PhoneNumber);
            if (!phoneUniq)
                return BadRequest(new {email = "user with this email already exists"});
            var usernameUniq = _userRepository.IsUsernameUniq(model.Username);
            if (!usernameUniq)
                return BadRequest(new {username = "user with this name already exists"});
            var id = Guid.NewGuid().ToString();
            var user = new User
            {
                Id = id,
                Username = model.Username,
                PhoneNumber = model.PhoneNumber,
                Password = _authService.HashPassword("password"),
                Role = model.Role,
                NeedChangePassword = true
            };
            _userRepository.Add(user);
            _userRepository.Commit();

            return _authService.GetAuthData(user);
        }
    }
}
