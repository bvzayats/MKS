using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NedoNet.API.Entities;
using NedoNet.API.UOF;

namespace NedoNet.API.Services {
    public class UsersService : IUsersService {
        private readonly IUnitOfWork _unitOfWork;

        public UsersService( IUnitOfWork unitOfWork ) {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserViewEntity> GetUserAsync( Guid id ) {
            return await _unitOfWork.UserRepository.GetByIdAsync( id );
        }

        public async Task<List<UserViewEntity>> GetPageAsync( int page ) {
            return await _unitOfWork.UserRepository.GetPageAsync( page );
        }
    }
}