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

                Dictionary<int, Student> _result = new Dictionary<int, Student>();
                for (int i = 0; i < students.Count; i++)
                    _result.Add(i + 1, students[i]);

                string result = JsonConvert.SerializeObject(_result, Formatting.Indented);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/Students/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Student student = new Student();
                student = sqlcomm.Select<Student>(String.Format("SELECT * FROM Student WHERE Id = {0}", id));

                string result = JsonConvert.SerializeObject(new { id, student }, Formatting.Indented);

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
                List<Student> students = new List<Student>();
                students = sqlcomm.SelectAll<Student>("SELECT * FROM Student").ToList();

                sqlcomm.Insert<Student>(String.Format("INSERT INTO dbo.Student (Id, FName, LName, IsGranted, Email) VALUES ({0}, '{1}', '{2}', {3}, '{4}')",
                                                                   students.Count + 1, value.FName, value.LName, value.IsGranted ? 1 : 0, value.Email));

                int id = students.Count + 1;

                string result = JsonConvert.SerializeObject(new { id, value }, Formatting.Indented);

                return Ok(result);
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
                sqlcomm.Update<Student>(String.Format("UPDATE Student SET FName = '{0}', LName = '{1}', IsGranted = {2}, Email = '{3}' WHERE Id = {4}",
                                                                                    value.FName, value.LName, value.IsGranted? 1 : 0, value.Email, id));

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
                sqlcomm.Delete<Student>(String.Format("DELETE FROM Student WHERE Id = {0}", id));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
