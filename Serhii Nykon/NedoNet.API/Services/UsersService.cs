using System;
using System.Collections.Generic;
using System.Data.SqlClient;
<<<<<<< .merge_file_a19176
using System.Text;
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
            using (SqlConnection connection = new SqlConnection( _connectionString )) {
                var command = new SqlCommand( $"SELECT * FROM USERS WHERE ID = N'{id}'", connection );
=======
using System.Threading.Tasks;
using NedoNet.API.Data.Models;

namespace NedoNet.API.Services {
    public class UsersService : IUsersService {
        private readonly string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=NedoNet;Trusted_Connection=True;";


        public async Task<User> GetUserAsync(Guid id) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand($"SELECT * FROM USERS WHERE ID = N'{id}'", connection);
>>>>>>> .merge_file_a14540
                User user = null;

                await connection.OpenAsync();
                var dr = await command.ExecuteReaderAsync();
                if (await dr.ReadAsync()) {
<<<<<<< .merge_file_a19176
                    user = UserFromDataReader( dr );
                }

                return _mapper.Map<UserViewEntity>( user );
            }
        }

        public async Task<List<UserViewEntity>> GetPageAsync( int page ) {
            using (SqlConnection connection = new SqlConnection( _connectionString )) {
                var command = new SqlCommand( $"EXEC sp_SelectUsersPage @PageNumber = {page}, @PageSize = 4",
                    connection );
=======
                    user = UserFromDataReader(dr);
                }

                return user;
            }
        }

        public async Task<List<User>> GetAllUsersAsync() {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand($"SELECT * FROM USERS", connection);
>>>>>>> .merge_file_a14540
                List<User> users = new List<User>();
                await connection.OpenAsync();
                var dr = await command.ExecuteReaderAsync();
                while (await dr.ReadAsync()) {
<<<<<<< .merge_file_a19176
                    users.Add( UserFromDataReader( dr ) );
                }

                return _mapper.Map<List<UserViewEntity>>( users );
            }
        }

        public UserViewEntity CreateUser( CreateUserEntity userEntity ) {
            var user = _mapper.Map<User>( userEntity );

            using (SqlConnection connection = new SqlConnection( _connectionString )) {
                StringBuilder commandText = new StringBuilder();
                commandText
                    .Append( $"INSERT INTO Users (Email, Password, FirstName, LastName, PhoneNumber)" )
                    .Append(
                        $"VALUES ('{user.Email}', '{user.Password}', '{user.FirstName}', '{user.LastName}', '{user.PhoneNumber}')" );

                var command = new SqlCommand( commandText.ToString(), connection );

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                var userView = _mapper.Map<UserViewEntity>( user );
                return userView;
            }
        }

        public UserViewEntity UpdateUser( Guid userId, UpdateUserEntity updateUserEntity ) {
            var user = _mapper.Map<User>( updateUserEntity );

            using (SqlConnection connection = new SqlConnection( _connectionString )) {
                var commandText = new StringBuilder();
                commandText
                    .Append( $"UPDATE Users SET " )
                    .Append( $"Email = '{user.Email}', Password = '{user.Password}', FirstName = '{user.FirstName}', " )
                    .Append( $"LastName = '{user.LastName}', PhoneNumber = '{user.PhoneNumber}'" );

                commandText.Append( $" WHERE Id = N'{userId}'" );
                var command = new SqlCommand( commandText.ToString(), connection );

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                var userView = _mapper.Map<UserViewEntity>( user );
                return userView;
            }
        }

        public void DeleteUser( Guid userId ) {
            using (SqlConnection connection = new SqlConnection( _connectionString )) {
                var command = new SqlCommand( $"DELETE FROM Users WHERE Id = N'{userId}'", connection );
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
=======
                    users.Add(UserFromDataReader(dr));
                }

                return users;
>>>>>>> .merge_file_a14540
            }
        }

        private User UserFromDataReader(SqlDataReader dr)
        {
<<<<<<< .merge_file_a19176
            return new User {
=======
            return new User
            {
>>>>>>> .merge_file_a14540
                Id = Guid.Parse(dr["Id"].ToString()),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Email = dr["Email"].ToString(),
                PhoneNumber = dr["PhoneNumber"].ToString()
            };
        }
    }
}