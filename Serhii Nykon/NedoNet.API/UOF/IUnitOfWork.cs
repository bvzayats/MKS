using System.Threading.Tasks;
using NedoNet.API.Repositories;

namespace NedoNet.API.UOF {
    public interface IUnitOfWork {
        IUsersRepository UserRepository { get; }
    }
}