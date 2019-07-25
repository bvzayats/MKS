using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPISwagger.Controllers
{
    [Route("api/[controller]")]
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


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                using (UniversityContext db = new UniversityContext())
                {
                    var student = db.Students.Find(id);

                    if (student == null)
                    {
                        return NotFound();
                    }

                    return Ok(student);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Students value)
        {
            try
            {
                using (UniversityContext db = new UniversityContext())
                {
                    db.Students.Add(value);

                    db.SaveChanges();

                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Students value)
        {
            try
            {
                using (UniversityContext db = new UniversityContext())
                {
                    var student = db.Students.FirstOrDefault(e => e.Id == id);

                    if (student != null)
                    {
                        student.Name = value.Name;
                        student.Surname = value.Surname;
                        student.Faculty = value.Faculty;
                        student.Course = value.Course;
                        student.NumberHostel = value.NumberHostel;

                        db.SaveChanges();

                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                using (UniversityContext db = new UniversityContext())
                {
                    var student = db.Students.Find(id);

                    if (student == null)
                    {
                        return NotFound();
                    }

                    db.Students.Remove(student);
                    db.SaveChanges();

                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}