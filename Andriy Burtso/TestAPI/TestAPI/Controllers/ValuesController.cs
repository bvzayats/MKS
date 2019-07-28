using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestAPI.Models;
using Newtonsoft.Json;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UserService _userService;
        public ValuesController()
        {

            _userService = new UserService();
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //UserService userService = new UserService();
            return Ok(_userService.GetList().ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            
            return Ok(_userService.GetById(id));
            
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            _userService.Create(value);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
