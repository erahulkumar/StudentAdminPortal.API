using Microsoft.EntityFrameworkCore;

namespace StudentAdminPortal.API.DataModels
{
    public class StudentAdminDbContext:DbContext
    {
        public StudentAdminDbContext(DbContextOptions<StudentAdminDbContext> options):base(options)
        { }
        public DbSet<Student> Student { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address  { get; set; }

    }
}
