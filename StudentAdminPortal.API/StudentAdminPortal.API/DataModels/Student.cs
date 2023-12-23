namespace StudentAdminPortal.API.DataModels
{
    public class Student
    {
        public Guid Id  { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required long Mobile { get; set; }
        public required string ProfileImageUrl { get; set; }

        public required Guid GenderId { get; set; }

        //Navigate property
        public required Gender Gender { get; set; }
        //Navigate property
        public required Address Address { get; set; }
    }
}
