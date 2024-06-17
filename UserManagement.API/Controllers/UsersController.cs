// UsersController.cs
using Microsoft.AspNetCore.Mvc;
using UserManagement.Business;
using UserManagement.Models;
using System.Threading.Tasks;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userService.CreateUser(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            user.Id = id;
            await _userService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeactivateUser(string id)
        {
            await _userService.DeactivateUser(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() 
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
