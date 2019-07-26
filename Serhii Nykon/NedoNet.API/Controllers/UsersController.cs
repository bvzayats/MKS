using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NedoNet.API.BindingModels;
using NedoNet.API.Exceptions;
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
            return Ok( users );
        }

        [HttpGet]
        [Route( "{id}" )]
        public async Task<IActionResult> GetUser( Guid id ) {
            var user = await _usersService.GetUserAsync(id);
            if (user is null) {
                return NotFound();
            }

            return Ok( user );
        }

        [HttpPost]
        public IActionResult CreateUser( [FromBody] UserBindingModel model ) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var user = _usersService.CreateUser(model);
            return Ok(user);
            }

        [HttpPut]
        [Route( "{id}" )]
        public async Task<IActionResult> UpdateUser( Guid id, [FromBody] UserBindingModel model ) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                var user = await _usersService.UpdateUserAsync(id, model);
                return Ok(user);
            }
            catch (ItemNotFoundException e) {
                return BadRequest( e );
            }
        }

        [HttpDelete]
        [Route( "{id}" )]
        public async Task<IActionResult> DeleteUser( Guid id ) {
            try {
                await _usersService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (ItemNotFoundException e) {
                return BadRequest( e );
            }
        }
    }
}