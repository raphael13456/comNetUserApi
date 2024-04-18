using comNetUserApi.Data;
using comNetUserApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace comNetUserApi.Controllers
{

    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository repos, ILogger<UserController> logger)
        {
            _userRepository = repos;       
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddUser([FromBody] UserAddDto user)
        {
            var newUser = new User()
            {
                Email = user.Email,
                Lastname = user.Lastname,
                Username = user.Username,
                Surname = user.Surname,
            };

            _userRepository.AddUser(newUser);
            return Created();
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {         
            return Ok(_userRepository.GetUsers());
        }
    }
}
