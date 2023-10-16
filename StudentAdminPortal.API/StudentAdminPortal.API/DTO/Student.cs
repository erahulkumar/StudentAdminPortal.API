using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.DTO
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Moblie { get; set; }
        public string ProfileImageUrl { get; set; }

        public Guid GenderId { get; set; }

        //Navigate property
        public Gender Gender { get; set; }
        //Navigate property
        public Address Address { get; set; }
    }
}
