using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NedoNet.API.Repositories;
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
        [Route( "{userId}" )]
        public async Task<IActionResult> GetUserAsync( Guid userId ) {

            var user = await _usersService.GetUserAsync( userId );
            return Ok(user);
        }
    }
}