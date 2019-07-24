using System;
using System.Threading.Tasks;
using NedoNet.API.Entities;

namespace NedoNet.API.Services {
    public interface IUsersService {
        Task<UserViewEntity> GetUser( Guid id );
    }
}