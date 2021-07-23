using Microsoft.EntityFrameworkCore;

namespace Students.DB
{
    public class AppDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProgress> StudentProgress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                @"Host=localhost;Database=StudentsDB;Username=postgres;Password=123456");
        }
    }
}
