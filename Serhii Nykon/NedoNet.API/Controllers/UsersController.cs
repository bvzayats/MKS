using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NedoNet.API.Data.Models;

namespace NedoNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        [HttpGet]
        [Route("testUser")]
        public IActionResult GetUser() {
            return Ok( new User {
                Id = Guid.NewGuid(),
                Email = "testEmail",
                FirstName = "testFirstName",
                LastName = "testLastName",
                PhoneNumber = "+380974925772"
            } );
        }
    }
}