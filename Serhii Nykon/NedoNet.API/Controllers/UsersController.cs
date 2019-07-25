using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NedoNet.API.Entities;
using NedoNet.API.Services;

namespace NedoNet.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly IUsersService _usersService;

        public UsersController( IUsersService usersService ) {
            _usersService = usersService;
        }

        [HttpGet]
        [Route( "user/{id}" )]
        public async Task<IActionResult> GetUserAsync( Guid id ) {

            try {
                var user = await _usersService.GetUserAsync( id );
                return Ok( user );
            }
            catch (Exception) {
                return StatusCode( StatusCodes.Status500InternalServerError );
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersPageAsync([FromQuery] int page) {
            if (page <= 0) {
                return BadRequest();
            }

            try {
                var users = await _usersService.GetPageAsync(page);
                if (users.Count == 0) {
                    return NotFound();
                }

                return Ok( users );
            }
            catch (Exception) {
                return StatusCode( StatusCodes.Status500InternalServerError );
            }
        }

        [HttpPost]
        public IActionResult CreateUser( [FromBody] CreateUserEntity userEntity ) {
            if ( !ModelState.IsValid ) {
                return BadRequest( ModelState );
            }

            try {
                var user = _usersService.CreateUser( userEntity );
                return Ok( user );
            }
            catch (Exception) {
                return StatusCode( StatusCodes.Status500InternalServerError );
            }
        }

        [HttpPut]
        [Route( "{id}" )]
        public IActionResult UpdateUser( Guid id, [FromBody] UpdateUserEntity userEntity ) {
            if ( !ModelState.IsValid ) {
                return BadRequest( ModelState );
            }

            try {
                var result = _usersService.UpdateUser( id, userEntity );
                return Ok( result );
            }
            catch (Exception) {
                return StatusCode( StatusCodes.Status500InternalServerError );
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser( Guid id ) {
            try {
                _usersService.DeleteUser( id );
                return NoContent();
            }
            catch (Exception) {
                return StatusCode( StatusCodes.Status500InternalServerError );
            }
        }
    }
}