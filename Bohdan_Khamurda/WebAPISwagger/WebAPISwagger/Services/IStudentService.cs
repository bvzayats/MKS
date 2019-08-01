using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPISwagger.Models;

namespace WebAPISwagger.Services {
    public interface IStudentService {

        Task<List<Student>> GetStudents();
        Task<Student> GetStudent( int id );
        Task<Student> PutStudent( int id, Student student );
        Task<Student> PostStudent( Student student );
        Task DeleteStudent( int id );

    }
}
