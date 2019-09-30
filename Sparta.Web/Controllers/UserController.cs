using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sparta.Web.API.Services;
using Sparta.Web.API.ViewModel;
using Sparta.Web.Data.Repositories;
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
            var t = HttpContext.User.Claims;
            return _userRepository.GetSingle(id);
        }

        [HttpGet("users")]
        public ActionResult<object> GetUsers()
        {
            var t = HttpContext.User.Claims;
            return new
            {
                current_user = t.ToList()[0].Value,
                role = t.ToList()[1].Value,
                users = _userRepository.GetAll().ToArray()

            };
        }
    }
}
