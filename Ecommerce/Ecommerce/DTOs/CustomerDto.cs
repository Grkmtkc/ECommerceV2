namespace ECommerce.API.DTOs
{
    public class CustomerDto : BaseEntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
        public ICollection<CommunicationDto> Communications { get; set; }
        public ICollection<SaleDto> Sales { get; set; }
    }
}
