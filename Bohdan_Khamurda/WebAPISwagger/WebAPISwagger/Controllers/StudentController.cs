using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPISwagger.Controllers
{
    [Route]
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
    }
}