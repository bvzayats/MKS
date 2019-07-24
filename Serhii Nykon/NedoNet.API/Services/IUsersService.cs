using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NedoNet.API.Common;

namespace NedoNet.API.Services {
    public interface IUsersService {
        Task<OperationResult> GetUserAsync( Guid id );
        Task<OperationResult> GetPageAsync( int page );
    }
}