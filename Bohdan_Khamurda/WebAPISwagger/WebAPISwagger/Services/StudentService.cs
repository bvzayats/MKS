using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPISwagger.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebAPISwagger.Services {
    public class StudentService : IStudentService {

        private readonly UniversityContext _context;

        public StudentService( UniversityContext context ) {

            _context = context;
        }

        public async Task<List<Student>> GetStudents() {

            var student = await _context.Students.ToListAsync();

            return student;
        }

        public async Task<Student> GetStudent( int id ) {

            var student = await _context.Students.FindAsync( id );

            return student;
        }

        public async Task<Student> PutStudent( int id, Student student ) {

            var studentDB = await _context.Students.FindAsync( id );
            if (studentDB == null)
                return null;

            studentDB.Name = student.Name;
            studentDB.Surname = student.Surname;
            studentDB.Faculty = student.Faculty;
            studentDB.Course = student.Course;
            studentDB.NumberHostel = student.NumberHostel;

            _context.Entry( studentDB ).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return studentDB;
        }

        public async Task<Student> PostStudent( Student student ) {

            _context.Students.Add( student );
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task DeleteStudent(int id) {

            var student = _context.Students.Find( id );

            _context.Students.Remove( student );
            await _context.SaveChangesAsync();
        }
    }
}
