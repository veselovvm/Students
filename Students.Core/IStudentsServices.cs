using Students.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Students.Core
{
    public interface IStudentsServices
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task DeleteStudentAsync(Student student);
        Task<Student> EditStudentAsync(Student student);
    }
}
