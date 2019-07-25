using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPISwagger.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (UniversityContext db = new UniversityContext())
                {
                    if (db.Students.ToList().Count != 0)
                        return Ok(db.Students.ToList());
                    else
                        return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return null;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Students value)
        {
            return null;
        }


        [HttpPut]
        public IActionResult Put(int id, [FromBody] Students value)
        {
            return null;
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}