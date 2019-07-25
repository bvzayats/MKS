using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using NedoNet.API.Data.Models;

namespace NedoNet.API.Services {
    public class UsersService : IUsersService {
        private readonly string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=NedoNet;Trusted_Connection=True;";


        public async Task<User> GetUserAsync(Guid id) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand($"SELECT * FROM USERS WHERE ID = N'{id}'", connection);
                User user = null;

                await connection.OpenAsync();
                var dr = await command.ExecuteReaderAsync();
                if (await dr.ReadAsync()) {
                    user = UserFromDataReader(dr);
                }

                return user;
            }
        }

        public async Task<List<User>> GetAllUsersAsync() {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand($"SELECT * FROM USERS", connection);
                List<User> users = new List<User>();
                await connection.OpenAsync();
                var dr = await command.ExecuteReaderAsync();
                while (await dr.ReadAsync()) {
                    users.Add(UserFromDataReader(dr));
                }

                return users;
            }
        }

        private User UserFromDataReader(SqlDataReader dr)
        {
            return new User
            {
                Id = Guid.Parse(dr["Id"].ToString()),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Email = dr["Email"].ToString(),
                PhoneNumber = dr["PhoneNumber"].ToString()
            };
        }
    }
}