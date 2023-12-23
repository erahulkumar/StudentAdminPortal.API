namespace StudentAdminPortal.API.DTO
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public required string PhysicalAddress { get; set; }
        public required string PostalAddress { get; set; }
        //Navigate property
        public Guid StudentId { get; set; }
    }
}
