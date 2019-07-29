using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tetiana_Test.Models;

namespace Tetiana_Test.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
          // GET api/movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieModel>> Get()
        {
            List<MovieModel> movieModel = Tetiana_Test.Services.Services.Get();
            return Ok(movieModel);
                   
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/movies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
