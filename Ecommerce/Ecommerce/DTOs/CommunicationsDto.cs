namespace ECommerce.API.DTOs
{
    public class CommunicationsDto : BaseEntityDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<CustomerDto> Customers { get; set; }
    }
}
