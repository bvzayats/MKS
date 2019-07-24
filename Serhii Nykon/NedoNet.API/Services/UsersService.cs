using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AutoMapper;
using NedoNet.API.Common;
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

        public async Task<OperationResult> GetUserAsync( Guid id ) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand($"SELECT * FROM USERS WHERE ID = N'{ id }'", connection);
                User user = null;
                try {
                    await connection.OpenAsync();
                    var dr = await command.ExecuteReaderAsync();
                    if (await dr.ReadAsync()) {
                        user = CreateUser(dr);
                    }

                    return OperationResult.Success(_mapper.Map<UserViewEntity>(user));
                } catch (Exception e) {
                    return OperationResult.Error( e.Message );
                }
            }
        }

        public async Task<OperationResult> GetPageAsync( int page ) {
            using (SqlConnection connection = new SqlConnection( _connectionString )) 
            {
                var command = new SqlCommand($"EXEC sp_SelectUsersPage @PageNumber = { page }, @PageSize = 4", connection );
                List<User> users = new List<User>();
                try {
                    await connection.OpenAsync();
                    var dr = await command.ExecuteReaderAsync();
                    while (await dr.ReadAsync()) {
                        users.Add( CreateUser( dr ) );
                    }

                    return OperationResult.Success(_mapper.Map<List<UserViewEntity>>(users));
                } catch (Exception e) {
                    return OperationResult.Error(e.Message);
                }
            }
        }

        public OperationResult CreateUserAsync(CreateUserEntity userEntity) {
            var user = _mapper.Map<User>( userEntity );

            using (SqlConnection connection = new SqlConnection( _connectionString )) {
                var command = new SqlCommand( $"INSERT INTO Users (Email, Password, FirstName, LastName, PhoneNumber) " +
                                              $"VALUES ('{user.Email}', '{user.Password}', '{user.FirstName}', '{user.LastName}', '{user.PhoneNumber}')", connection);
                try {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    var userView = _mapper.Map<UserViewEntity>( user );
                    return OperationResult.Success( userView );
                } catch (Exception e) {
                    return OperationResult.Error( e.Message );
                }
            }
        }

        private User CreateUser(SqlDataReader dr)
        {
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