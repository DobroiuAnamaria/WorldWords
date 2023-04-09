using WebApplication1.Model;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service;

namespace WebApplication1.Controler
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UserService _userService;

        public UsersController(ILogger<UsersController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> Get()
        {

            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Add(UserViewModel user)
        {
            return Ok(await _userService.AddUserASync(user));
        }

        [HttpPut]
        public async Task<ActionResult<UserViewModel>> Update(UserUpdateViewModel user)
        {
            return Ok(await _userService.UpdateUserAsync(user));
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return Ok(await _userService.DeleteUserAsync(id));
        }
    }
}
