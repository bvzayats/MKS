using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AutoMapper;
using NedoNet.API.Data.Models;
using NedoNet.API.Entities;

namespace NedoNet.API.Repositories {
    public class UsersRepository : IUsersRepository {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public UsersRepository( string connectionString, IMapper mapper) {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        public async Task<UserViewEntity> GetByIdAsync( Guid userId ) {
            using ( SqlConnection connection = new SqlConnection( _connectionString )) {
                var command = new SqlCommand($"SELECT * FROM USERS WHERE ID = N'{userId}'", connection);
                User user = null;
                try {
                    await connection.OpenAsync();
                    var dr = command.ExecuteReader();
                    if (await dr.ReadAsync()) {
                        user = new User {
                            Id = Guid.Parse( dr["Id"].ToString() ),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Email = dr["Email"].ToString(),
                            PhoneNumber = dr["PhoneNumber"].ToString()
                        };
                    }
                    return _mapper.Map<UserViewEntity>(user);
                }
                catch {
                    return null;
                }
            }
        }
    }
}