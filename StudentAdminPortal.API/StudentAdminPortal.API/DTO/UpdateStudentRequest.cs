namespace StudentAdminPortal.API.DTO
{
    public class UpdateStudentRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string DateOfBirth { get; set; }
        public required string Email { get; set; }
        public long Mobile { get; set; }
        public Guid GenderId { get; set; }
        public required string PhysicalAddress { get; set; }
        public required string PostalAddress { get; set; }
    }
}
