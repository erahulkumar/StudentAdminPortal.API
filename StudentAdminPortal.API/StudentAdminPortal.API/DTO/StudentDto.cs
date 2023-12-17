using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.DTO
{
    public class StudentDto
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
        public GenderDto Gender { get; set; }
        //Navigate property
        public AddressDto Address { get; set; }
    }
}
