using System;
using System.Collections.Generic;
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
                    var dr = await command.ExecuteReaderAsync();
                    if (await dr.ReadAsync()) {
                        user = CreateUser( dr );
                    }

                    return _mapper.Map<UserViewEntity>(user);
                }
                catch {
                    return null;
                }
            }
        }

        public async Task<List<UserViewEntity>> GetPageAsync( int page ) {
            using ( SqlConnection connection = new SqlConnection( _connectionString )) {
                var command = new SqlCommand( $"EXEC sp_SelectUsersPage @PageNumber = {page}, @PageSize = 4", connection );
                List<User> users = new List<User>();
                try {
                    await connection.OpenAsync();
                    var dr = await command.ExecuteReaderAsync();
                    while (await dr.ReadAsync()) {
                        users.Add(CreateUser( dr ));
                    }

                    return _mapper.Map<List<UserViewEntity>>( users );
                } catch {
                    return null;
                }
            }
        }

        private User CreateUser(SqlDataReader dr) {
            return new User {
                Id = Guid.Parse(dr["Id"].ToString()),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Email = dr["Email"].ToString(),
                PhoneNumber = dr["PhoneNumber"].ToString()
            };
        }
    }
}