using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<User> GetUser(string id)
        {
            return _userRepository.GetSingle(id);
        }

        [HttpGet("users")]
        public ActionResult<object> GetUsers()
        {
            var claims = HttpContext?.User?.Claims.ToArray() ?? new Claim[1];
            return new
            {
                current_user = claims[0].Value,
                role = claims[1].Value,
                users = _userRepository.GetAll().ToArray()

            };
        }
    }
}
