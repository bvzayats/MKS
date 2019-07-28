using System;
using System.Collections.Generic;
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
                Student student = new Student();
                student = sqlcomm.Select(id);

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
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(value);
                if (!Validator.TryValidateObject(value, validationContext, validationResults, true))
                    throw new ValidationException();

                int id = sqlcomm.SelectAll().Count + 1;
                sqlcomm.Insert(id, value);

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
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(value);
                if (!Validator.TryValidateObject(value, validationContext, validationResults, true))
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

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
