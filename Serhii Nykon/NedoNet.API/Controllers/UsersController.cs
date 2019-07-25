using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NedoNet.API.Data.Models;
using NedoNet.API.Services;

namespace NedoNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly IUsersService _usersService;

        public UsersController( IUsersService usersService ) {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() {
            var users = await _usersService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser(Guid id) {
            var user = await _usersService.GetUserAsync(id);
            if (user is null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user) {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] User user) {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(Guid id) {
            return NoContent();
        }
    }
}