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
        public ICollection<AddressesDto> Addresses { get; set; }
        public ICollection<CommunicationsDto> Communications { get; set; }
        public ICollection<SalesDto> Sales { get; set; }
    }
}
