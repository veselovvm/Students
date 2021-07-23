using System.ComponentModel.DataAnnotations;

namespace Students.DB
{
    public class StudentProgress
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
