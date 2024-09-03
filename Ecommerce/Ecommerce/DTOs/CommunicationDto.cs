namespace ECommerce.API.DTOs
{
    public class CommunicationDto : BaseEntityDto
    {
   
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
      
    }
}
