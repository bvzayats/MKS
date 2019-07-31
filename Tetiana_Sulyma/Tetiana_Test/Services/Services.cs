using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Tetiana_Test.Models;

namespace Tetiana_Test.Services
{
    public static class Services
    {
       const string connString = @"Data Source=DESKTOP-9D62NQR\SQL2017;Database=Films;Integrated Security=True";
        const string query = "SELECT * from Movies";

        public static List<MovieModel> Get()
        {
            var movieModels = new List<MovieModel>();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
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
    }
}
