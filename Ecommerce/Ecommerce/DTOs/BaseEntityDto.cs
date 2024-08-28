namespace ECommerce.API.DTOs
{
    public abstract class BaseEntityDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}
