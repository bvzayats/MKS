using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Tetiana_Test.Models;
using System;

namespace Tetiana_Test.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        
        // GET api/movies
        [HttpGet]
        public IEnumerable<MovieModel> Get()
        {
            string connString = @"Data Source=DESKTOP-9D62NQR\SQL2017;Database=Films;Integrated Security=True";
            string query = "SELECT * from Movies";
            var movieModels = new List<MovieModel>();
            using (SqlConnection connection =
              new SqlConnection(connString))
            {
                SqlCommand command =
                    new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
               
               
                while (reader.Read())
                {

                    movieModels.Add(new MovieModel
                    {
                        Id = Int32.Parse(reader[0].ToString()),
                        Title = reader[1].ToString(),
                        Year = Int32.Parse(reader[2].ToString()),
                        Genre = reader[3].ToString(),
                        Country = reader[4].ToString(),
                        IMDb = Convert.ToSingle(reader[5].ToString()),
                        Critical_acclaim = reader[6].ToString(),


                });
            }

                
                reader.Close();
            }

           
            return movieModels;
                
                
        

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
