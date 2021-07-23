using Students.DB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Students.Core
{
    public class StudentsServices : IStudentsServices
    {
        private AppDbContext _context;

        public StudentsServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            StudentProgress studentProgress = await _context.StudentProgress
                .Where(c => c.Id == ((StudentProgress)student.Progress).Id)
                .FirstOrDefaultAsync();

            Student dbStudent = new Student
            {
                Fio = student.Fio,
                Birthday = student.Birthday,
                Progress = studentProgress
            };

            _context.Students.Add(dbStudent);
            await _context.SaveChangesAsync();

            return dbStudent;
        }

        public async Task DeleteStudentAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> EditStudentAsync(Student student)
        {
            Student dbStudent = await _context.Students.Include(p => p.Progress)
                .SingleOrDefaultAsync(s => s.Id == student.Id);

            //var dbStudent = _context.Students.First(s => s.Id == student.Id);
            dbStudent.Fio = student.Fio;
            dbStudent.Birthday = student.Birthday;
            dbStudent.Progress = student.Progress;
            await _context.SaveChangesAsync();

            return dbStudent;
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            Student student = await _context.Students.Include(p => p.Progress)
                .SingleOrDefaultAsync(s => s.Id == id);

            return student;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var students = _context.Students.Include(c => c.Progress);
            return await students.ToListAsync();
        }
    }
}
