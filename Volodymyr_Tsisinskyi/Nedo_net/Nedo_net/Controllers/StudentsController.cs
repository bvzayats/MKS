using System;
using Microsoft.AspNetCore.Mvc;
using Nedo_net.Entities;
using Nedo_net.Database;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
                string result = JsonConvert.SerializeObject(sqlcomm.SelectAll(), Formatting.Indented);
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
                string result = JsonConvert.SerializeObject( sqlcomm.Select( id ), Formatting.Indented );
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/Students
        [HttpPost]
        public IActionResult Post([FromBody] StudentDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new ValidationException();

                int id = sqlcomm.SelectAll().Count + 1;
                sqlcomm.Insert(id, value);

                string result = JsonConvert.SerializeObject( new Student( id, value ), Formatting.Indented );
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/Students/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new ValidationException();

                sqlcomm.Update(id, value);

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
                sqlcomm.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
