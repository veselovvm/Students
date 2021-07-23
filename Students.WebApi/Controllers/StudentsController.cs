using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Students.Core;
using Students.DB;

namespace Students.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private IStudentsServices _studentsServices;
        
        public StudentsController(IStudentsServices studentsServices)
        {
            _studentsServices = studentsServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _studentsServices.GetStudentsAsync());
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentsServices.GetStudentAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync(Student student)
        {
            var newStudent = await _studentsServices.CreateStudentAsync(student);
            return CreatedAtRoute(nameof(GetStudent), new { newStudent.Id}, newStudent);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(Student student)
        {
            await _studentsServices.DeleteStudentAsync(student);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditStudent(Student student)
        {
            return Ok(await _studentsServices.EditStudentAsync(student));
        }
    }
}
