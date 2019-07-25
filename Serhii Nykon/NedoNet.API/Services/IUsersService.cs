using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NedoNet.API.Data.Models;
using NedoNet.API.Entities;

namespace NedoNet.API.Services {
    public interface IUsersService {
        Task<List<UserViewEntity>> GetAllUsersAsync(  );
        Task<UserViewEntity> GetUserAsync(Guid id);
        UserViewEntity CreateUser(CreateUserEntity userEntity);
        Task<UserViewEntity> UpdateUserAsync(Guid userId, UpdateUserEntity user);
        Task DeleteUserAsync(Guid userId);
    }
}