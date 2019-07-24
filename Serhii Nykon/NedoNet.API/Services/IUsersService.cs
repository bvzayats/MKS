using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NedoNet.API.Entities;

namespace NedoNet.API.Services {
    public interface IUsersService {
        Task<UserViewEntity> GetUserAsync( Guid id );
        Task<List<UserViewEntity>> GetPageAsync( int page );
    }
}