using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentAsync();
        Task<Student?> GetStudentsByIdAsync(Guid Id);
    }
}
