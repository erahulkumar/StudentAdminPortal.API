using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminDbContext dbContext;

        public SqlStudentRepository(StudentAdminDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await dbContext.Gender.ToListAsync();   
        }

        public async Task<Student?> GetStudentAsync(Guid studentId)
        {
            return await dbContext.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await dbContext.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();

        }
    }
}

