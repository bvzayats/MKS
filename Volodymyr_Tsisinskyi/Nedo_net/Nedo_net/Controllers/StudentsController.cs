using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nedo_net.Entities;
using Nedo_net.Database;
using System.Linq;
using Newtonsoft.Json;

namespace Nedo_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        SQLcommands sqlcomm = new SQLcommands();

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Student> students = new List<Student>();
                students = sqlcomm.SelectAll<Student>("SELECT * FROM Student").ToList();

                string result = JsonConvert.SerializeObject(students, Formatting.None);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Student student = new Student();
                student = sqlcomm.Select<Student>(String.Format("SELECT * FROM Student WHERE Id={0}", id));

                string result = JsonConvert.SerializeObject(student, Formatting.None);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
