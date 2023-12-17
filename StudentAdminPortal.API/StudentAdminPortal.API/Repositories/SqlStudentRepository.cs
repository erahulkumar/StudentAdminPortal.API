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
        public async Task<List<Student>> GetStudentAsync()
        {
            return await dbContext.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();

        }

        public async Task<Student?> GetStudentsByIdAsync(Guid Id)
        {
            return await dbContext.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x=>x.Id==Id);
        }
    }
}

