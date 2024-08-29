namespace ECommerce.API.DTOs
{
    public class AddressDto : BaseEntityDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<CustomerDto> Customers { get; set; }
    }
}
