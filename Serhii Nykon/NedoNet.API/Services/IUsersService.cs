using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NedoNet.API.Common;
using NedoNet.API.Data.Models;
using NedoNet.API.Entities;

namespace NedoNet.API.Services {
    public interface IUsersService {
        Task<OperationResult> GetUserAsync( Guid id );
        Task<OperationResult> GetPageAsync( int page );
        OperationResult CreateUser( CreateUserEntity userEntity );
        OperationResult UpdateUser( Guid userId, UpdateUserEntity user );
    }
}