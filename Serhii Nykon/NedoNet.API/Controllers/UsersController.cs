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
        public IActionResult GetUser() {
            return Ok( new User {
                Id = Guid.NewGuid(),
                Email = "testEmail",
                FirstName = "testFirstName",
                LastName = "testLastName",
                PhoneNumber = "+380974925772"
            } );
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(Guid id) {

            return Ok();
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