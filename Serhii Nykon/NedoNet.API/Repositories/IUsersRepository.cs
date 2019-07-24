using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NedoNet.API.Data.Models;
using NedoNet.API.Entities;

namespace NedoNet.API.Repositories {
    public interface IUsersRepository {
        Task<UserViewEntity> GetByIdAsync( Guid userId );
        Task<List<UserViewEntity>> GetPageAsync( int page );
    }
}