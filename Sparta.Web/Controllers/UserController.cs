using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sparta.Web.API.Services.Abstract;
using Sparta.Web.API.ViewModel;
using Sparta.Web.Data.Abstract;
using Sparta.Web.Model;

namespace Sparta.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UserController(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserInfo> GetUser(string id)
        {
            var user = _userRepository.GetSingle(id);
            return UserInfo.Factory(user.Id, user.Username, user.RealName, user.PhoneNumber, user.Role);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("remove/{id}")]
        public ActionResult<UserInfo> RemoveUser(string id)
        {
            var user = _userRepository.GetSingle(id);
            _userRepository.Delete(user);
            _userRepository.Commit();
            return UserInfo.Factory(user.Id, user.Username, user.RealName, user.PhoneNumber, user.Role);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("update")]
        public ActionResult<UserInfo> UpdateUser(EditUserViewModal model)
        {
            var usernameUniq = _userRepository.FindBy(u=>u.Username == model.Username).Count() == 1;
            if (!usernameUniq)
                return BadRequest(new { username = "user with this name already exists" });

            var user = _userRepository.GetSingle(model.Id);
            user.Username = model.Username;
            user.PhoneNumber = model.PhoneNumber;
            user.RealName = model.RealName;
            if (model.IsDropPassword)
                user.Password = _authService.HashPassword("password");
            user.Role = model.Role;
            user.NeedChangePassword = model.IsDropPassword;

            _userRepository.Update(user);
            _userRepository.Commit();

            return UserInfo.Factory(user.Id, user.Username, user.RealName, user.PhoneNumber, user.Role);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("add")]
        public ActionResult<UserInfo> AddUser(EditUserViewModal model)
        {
            var usernameUniq = _userRepository.IsUsernameUniq(model.Username);
            if (!usernameUniq)
                return BadRequest(new { username = "user with this name already exists" });
            var id = Guid.NewGuid().ToString();
            var user = new User
            {
                Id = id,
                Username = model.Username,
                RealName = model.RealName,
                PhoneNumber = model.PhoneNumber,
                Password = _authService.HashPassword("password"),
                Role = model.Role,
                NeedChangePassword = true
            };
            _userRepository.Add(user);
            _userRepository.Commit();
            return UserInfo.Factory(user.Id, user.Username, user.RealName, user.PhoneNumber, user.Role);
        }

        [HttpGet("users")]
        public ActionResult<UserInfo[]> GetUsers()
        {
            return _userRepository.GetAll().Select(u => UserInfo.Factory(u.Id, u.Username, u.RealName, u.PhoneNumber, u.Role)).ToArray();

        }
    }
}
