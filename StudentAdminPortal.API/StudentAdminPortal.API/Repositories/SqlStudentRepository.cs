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

        public async Task<Student> AddStudentAsync(Student request)
        {
            var student=await dbContext.Student.AddAsync(request);
            await dbContext.SaveChangesAsync();
            return student.Entity;
        }

        public async Task<Student?> DeleteStudentAsync(Guid studentId)
        {
            var student = await GetStudentAsync(studentId);
            if (student != null)
            {
                dbContext.Student.Remove(student);
                dbContext.SaveChanges();
                return student;
            }

            return null;
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
            return await dbContext.Student.Include(nameof(Gender)).Include(nameof(Address)).OrderBy(x => x.FirstName).ToListAsync();

        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl)
        {
            var student =await GetStudentAsync(studentId);
            if (student != null)
            {
                student.ProfileImageUrl = profileImageUrl;
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
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

