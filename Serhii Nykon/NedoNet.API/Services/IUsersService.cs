using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NedoNet.API.Data.Models;
using NedoNet.API.Entities;

namespace NedoNet.API.Services {
    public interface IUsersService {
        Task<UserViewEntity> GetUserAsync( Guid id );
        Task<List<UserViewEntity>> GetPageAsync( int page );
        UserViewEntity CreateUser( CreateUserEntity userEntity );
        UserViewEntity UpdateUser( Guid userId, UpdateUserEntity user );
        void DeleteUser( Guid userId );
    }
}