using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bookish.Application;
using Bookish.Application.Interfaces;

namespace Bookish.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
    }
}
