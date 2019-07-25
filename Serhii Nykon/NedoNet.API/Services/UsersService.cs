using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NedoNet.API.BindingModels;
using NedoNet.API.Data.Models;
using NedoNet.API.Entities;
using NedoNet.API.Exceptions;
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

        public UserViewModel CreateUser(UserBindingModel model) {
            var user = _mapper.Map<User>(model);

            using (var connection = new SqlConnection(_connectionString)) {
                StringBuilder commandText = new StringBuilder();
                commandText
                    .Append($"INSERT INTO Users (Email, Password, FirstName, LastName, PhoneNumber)")
                    .Append($"VALUES ('{user.Email}', '{user.Password}', '{user.FirstName}', '{user.LastName}', '{user.PhoneNumber}')");

                var command = new SqlCommand(commandText.ToString(), connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                var userView = _mapper.Map<UserViewModel>(user);
                return userView;
            }
        }

        public async Task<UserViewModel> UpdateUserAsync(Guid userId, UserBindingModel model) {
            if (await GetUserAsync( userId ) is null) {
                throw new ItemNotFoundException($"No such user with id {userId}", userId);
            }

            var user = _mapper.Map<User>(model);

            using (var connection = new SqlConnection(_connectionString)) {
                var commandText = new StringBuilder();
                commandText
                    .Append($"UPDATE Users SET ")
                    .Append($"Email = '{user.Email}', Password = '{user.Password}', FirstName = '{user.FirstName}', ")
                    .Append($"LastName = '{user.LastName}', PhoneNumber = '{user.PhoneNumber}'");

                commandText.Append($" WHERE Id = N'{userId}'");
                var command = new SqlCommand(commandText.ToString(), connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                var userView = _mapper.Map<UserViewModel>(user);
                return userView;
            }
        }

        public async Task DeleteUserAsync(Guid userId) {
            if (await GetUserAsync( userId ) is null) {
                throw new ItemNotFoundException($"No such user with id {userId}", userId);
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
    }
}