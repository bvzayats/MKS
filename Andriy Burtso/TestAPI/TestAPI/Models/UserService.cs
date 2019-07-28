using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService() {
            _connectionString = @"Data Source=ANDRIY-PC\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public void Create(User user)
        {
            string sqlExpression = $"INSERT INTO [dbo].[User] (FirstName, LastName, Email, Age) VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', {user.Age})";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public List<User> GetList()
        {
            
            string sqlExpression = $"SELECT * FROM [dbo].[User]";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<User> allUsers = new List<User>();
                User user;
                while (reader.Read())
                {
                    user = new User();
                    user.Id = (int)reader.GetValue(0);
                    user.FirstName = (string)reader.GetValue(1);
                    user.LastName = (string)reader.GetValue(2);
                    user.Email = (string)reader.GetValue(3);
                    user.Age = (int)reader.GetValue(4);
                    allUsers.Add(user);
                }
                reader.Close();
                return allUsers;
            }
        }

        public User GetById(int id)
        {
            User user = new User();
            string sqlExpression = $"Select * From [dbo].[User] where Id = {id}";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                        user.Id = (int)reader.GetValue(0);
                        user.FirstName = (string)reader.GetValue(1);
                        user.LastName = (string)reader.GetValue(2);
                        user.Email = (string)reader.GetValue(3);
                        user.Age = (int)reader.GetValue(4);
                }
                reader.Close();
            }
            return user;
        }
    }
}
