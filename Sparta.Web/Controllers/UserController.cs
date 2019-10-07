using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<UserInfo> GetUser(string id)
        {
            var user = _userRepository.GetSingle(id);
            return new UserInfo
            {
                Username = user.Username,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            };
        }

        [HttpGet("users")]
        public ActionResult<UserInfo[]> GetUsers()
        {
            return _userRepository.GetAll().Select(u => new UserInfo
                {Username = u.Username, Id = u.Id, PhoneNumber = u.PhoneNumber, Role = u.Role}).ToArray();
            
        }
    }
}
