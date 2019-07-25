using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NedoNet.API.Data.Models;

namespace NedoNet.API.Services {
    public interface IUsersService {
        Task<User> GetUserAsync( Guid id );
        Task<List<User>> GetAllUsersAsync(  );
    }
}