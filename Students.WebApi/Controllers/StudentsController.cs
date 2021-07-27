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
            var dbStudent = await _studentsServices.GetStudentAsync(id);

            if (dbStudent == null)
                return NotFound();

            return Ok(dbStudent);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync(Student student)
        {
            var dbStudent = await _studentsServices.CreateStudentAsync(student);
            return CreatedAtRoute(nameof(GetStudent), new { dbStudent.Id}, dbStudent);
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
            var dbStudent = await _studentsServices.EditStudentAsync(student);
            if (dbStudent == null)
                return NotFound();
            
            return Ok(dbStudent);
        }
    }
}
