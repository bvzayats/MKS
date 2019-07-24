using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NedoNet.API.Entities;
using NedoNet.API.Services;

namespace NedoNet.API.Areas.v1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly IUsersService _usersService;

        private static readonly string ModelIsNotValidErrorMessage = "Model is not valid";

        public UsersController( IUsersService usersService ) {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUserAsync([FromQuery] Guid id) {

            var result = await _usersService.GetUserAsync( id );

            if ( result.IsSuccess ) {
                return Ok( result.Result );
            }

            return BadRequest( result.Result );
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersPageAsync([FromQuery] int page) {

            var result = await _usersService.GetPageAsync( page );

            if ( result.IsSuccess ) {
                return Ok( result.Result );
            }

            return BadRequest( result.Result );
        }
        }
    }
}