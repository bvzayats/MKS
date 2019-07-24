using System;
using System.Threading.Tasks;
using NedoNet.API.Entities;
using NedoNet.API.UOF;

namespace NedoNet.API.Services {
    public class UsersService : IUsersService {
        private readonly IUnitOfWork _unitOfWork;

        public UsersService( IUnitOfWork unitOfWork ) {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserViewEntity> GetUser( Guid id ) {
            return await _unitOfWork.UserRepository.GetById( id );
        }
    }
}