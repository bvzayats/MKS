using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NedoNet.API.Services;

namespace NedoNet.API.Areas.v1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly IUsersService _usersService;

        public UsersController( IUsersService usersService ) {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUserAsync([FromQuery] Guid id) {
            var result = await _usersService.GetUserAsync( id );

            return Ok(result.Result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersPage([FromQuery] int page) {
            var result = await _usersService.GetPageAsync( page );
            
            return Ok(result.Result);
        }
    }
}