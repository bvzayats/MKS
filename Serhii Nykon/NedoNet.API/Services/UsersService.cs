using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AutoMapper;
using NedoNet.API.Data.Models;
using NedoNet.API.Entities;

namespace NedoNet.API.Services {
    public class UsersService : IUsersService {
        private readonly IMapper _mapper;

        private readonly string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=NedoNet;Trusted_Connection=True;";

        public UsersService( IMapper mapper ) {
            _mapper = mapper;
        }

        public async Task<UserViewEntity> GetUserAsync( Guid id ) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand($"SELECT * FROM USERS WHERE ID = N'{ id }'", connection);
                User user = null;
                try
                {
                    await connection.OpenAsync();
                    var dr = await command.ExecuteReaderAsync();
                    if (await dr.ReadAsync())
                    {
                        user = CreateUser(dr);
                    }

                    return _mapper.Map<UserViewEntity>(user);
                }
                catch
                {
                    return null;
                }
            }
        }

        public async Task<List<UserViewEntity>> GetPageAsync( int page ) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand($"EXEC sp_SelectUsersPage @PageNumber = {page}, @PageSize = 4", connection);
                List<User> users = new List<User>();
                try
                {
                    await connection.OpenAsync();
                    var dr = await command.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        users.Add(CreateUser(dr));
                    }

                    return _mapper.Map<List<UserViewEntity>>(users);
                }
                catch
                {
                    return null;
                }
            }
        }

        private User CreateUser(SqlDataReader dr)
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