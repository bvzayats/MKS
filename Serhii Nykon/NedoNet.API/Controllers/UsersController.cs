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

        [HttpGet]
        [Route("user/{id}")]
        public IActionResult GetUser(Guid id) {

            return Ok();
        }

        [HttpGet]
        public IActionResult GetUsersPage([FromQuery] int page) {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateUser() {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser(Guid id) {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(Guid id) {
            return NoContent();
        }
    }
}