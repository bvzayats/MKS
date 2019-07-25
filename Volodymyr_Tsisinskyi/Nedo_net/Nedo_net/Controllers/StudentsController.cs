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

        // GET api/Students
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

        // GET api/Students/1
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

        // POST api/Students
        [HttpPost]
        public IActionResult Post([FromBody] Student value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/Students/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/Students/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
