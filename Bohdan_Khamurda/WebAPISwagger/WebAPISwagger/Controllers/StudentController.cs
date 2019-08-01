using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPISwagger.Models;
using WebAPISwagger.Services;

namespace WebAPISwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase {

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper ) {

            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {

            var students = await _studentService.GetStudents();

            return Ok( students );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {

            var student = await _studentService.GetStudent( id );

            return Ok( student );
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentDTO model) {

            if (!ModelState.IsValid) {
                return BadRequest( ModelState );
            }

            var student = _mapper.Map<Student>( model );
            var localStudent = await _studentService.PostStudent( student );

            return Ok( localStudent );
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentDTO model) {

            if (!ModelState.IsValid) {
                return BadRequest( ModelState );
            }

            var student = _mapper.Map<Student>( model );
            var localStudent = await _studentService.PutStudent( id, student );

            return Ok( localStudent );
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {

            await _studentService.DeleteStudent( id );

            return NoContent();
        }
    }
}