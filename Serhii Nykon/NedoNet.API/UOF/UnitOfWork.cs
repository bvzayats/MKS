using AutoMapper;
using NedoNet.API.Repositories;

namespace NedoNet.API.UOF {
    public class UnitOfWork : IUnitOfWork {
        private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=NedoNet;Trusted_Connection=True;";
        private readonly IMapper _mapper;
        private IUsersRepository _usersRepository;

        public UnitOfWork( IMapper mapper ) {
            _mapper = mapper;
        }

        public IUsersRepository UserRepository {
            get {
                return _usersRepository = _usersRepository ?? new UsersRepository( _connectionString,  _mapper );
            }
        }
    }
}