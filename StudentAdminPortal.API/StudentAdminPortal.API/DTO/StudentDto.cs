using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.DTO
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required long Moblie { get; set; }
        public required string ProfileImageUrl { get; set; }

        public Guid GenderId { get; set; }

        //Navigate property
        public required GenderDto Gender { get; set; }
        //Navigate property
        public required AddressDto Address { get; set; }
    }
}
