using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NedoNet.API.BindingModels;
using NedoNet.API.Data.Entities;
using NedoNet.API.Exceptions;
using NedoNet.API.Models;
using NedoNet.API.Helpers;

namespace NedoNet.API.Services {
    public class UsersService : IUsersService {

        private readonly IMapper _mapper;
        private readonly string _connectionString = ConnectionStringHelper.ConnectionString;

        public UsersService(IMapper mapper) {
            _mapper = mapper;
        }

        public async Task<UserViewModel> GetUserAsync(Guid id) {
            using (var connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand($"SELECT * FROM USERS WHERE ID = N'{ id }'", connection);
                User user = null;

                await connection.OpenAsync();
                var dr = await command.ExecuteReaderAsync();
                if (await dr.ReadAsync()) {
                    user = UserFromDataReader(dr);
                }

                if (user is null) {
                    throw new ItemNotFoundException( $"User with id {id} not found" );
                }
                connection.Close();

                return _mapper.Map<UserViewModel>( user );
            }
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync() {
            using (var connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand($"SELECT * FROM USERS", connection);
                List<User> users = new List<User>();
                await connection.OpenAsync();
                var dr = await command.ExecuteReaderAsync();
                while (await dr.ReadAsync()) {
                    users.Add(UserFromDataReader(dr));
                }

                return _mapper.Map<List<UserViewModel>>( users );
            }
        }

        public async Task<UserViewModel> CreateUser(UserBindingModel model) {
            var user = await GetUserByEmail( model.Email );
            if ( !(user is null) ) {
                throw new UserEmailAlreadyExistException($"User with email {model.Email} already exist.");
            }

            using (var connection = new SqlConnection(_connectionString)) {
                StringBuilder commandText = new StringBuilder();
                commandText
                    .Append("INSERT INTO Users (Email, Password, FirstName, LastName, PhoneNumber)")
                    .Append($"VALUES ('{model.Email}', '{model.Password}', '{model.FirstName}', '{model.LastName}', '{model.PhoneNumber}')");

                var command = new SqlCommand(commandText.ToString(), connection);

                connection.Open();
                await command.ExecuteNonQueryAsync();
                connection.Close();

                var userFromDb = await GetUserByEmail( model.Email );

                return _mapper.Map<UserViewModel>( userFromDb );
            }
        }

        public async Task<UserViewModel> UpdateUserAsync(Guid userId, UserBindingModel model) {
            var user = await GetUserAsync( userId );
            if (user is null) {
                throw new ItemNotFoundException($"No such user with id {userId}.");
            }

            using (var connection = new SqlConnection(_connectionString)) {
                var commandText = new StringBuilder();
                commandText
                    .Append("UPDATE Users SET ")
                    .Append($"Email = '{model.Email}', Password = '{model.Password}', FirstName = '{model.FirstName}', ")
                    .Append($"LastName = '{model.LastName}', PhoneNumber = '{model.PhoneNumber}'")
                    .Append($" WHERE Id = N'{userId}'");

                var command = new SqlCommand(commandText.ToString(), connection);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                connection.Close();

                var userView = _mapper.Map<UserViewModel>( model.Email );
                return userView;
            }
        }
        
        public async Task DeleteUserAsync(Guid userId) {
            var userFromDb = await GetUserAsync( userId );
            if (userFromDb is null) {
                throw new ItemNotFoundException($"No such user with id '{userId}'");
            }

            using (var connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand($"DELETE FROM Users WHERE Id = N'{userId}'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private User UserFromDataReader(SqlDataReader dr) {
            return new User {
                Id = Guid.Parse(dr["Id"].ToString()),
                Password = dr["Password"].ToString(),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Email = dr["Email"].ToString(),
                PhoneNumber = dr["PhoneNumber"].ToString()
            };
        }

        private async Task<User> GetUserByEmail( string email ) {
            using (var connection = new SqlConnection( _connectionString )) {
                string commandText = $"SELECT * FROM Users WHERE Email = '{email}'";
                var command = new SqlCommand( commandText, connection );

                User user = null;

                await connection.OpenAsync();
                var dr = await command.ExecuteReaderAsync();
                if (await dr.ReadAsync())
                {
                    user = UserFromDataReader(dr);
                }

                connection.Close();
                return user;
            }
        }
    }
}