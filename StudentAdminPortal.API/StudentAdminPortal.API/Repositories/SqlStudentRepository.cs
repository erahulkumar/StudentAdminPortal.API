using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<bool> Exists(Guid studentId)
        {
            return await dbContext.Student.AnyAsync(x => x.Id == studentId);
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

        public async Task<Student?> UpdateStudent(Guid studentId, Student request)
        {
            var existingStudent = await GetStudentAsync(studentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = request.FirstName;
                existingStudent.LastName = request.LastName;
                existingStudent.DateOfBirth = request.DateOfBirth;
                existingStudent.Email = request.Email;
                existingStudent.Mobile= request.Mobile;
                existingStudent.GenderId = request.GenderId;
                existingStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress = request.Address.PostalAddress;

                await dbContext.SaveChangesAsync();
                return existingStudent;

            }
            return null;
        }
    }
}

