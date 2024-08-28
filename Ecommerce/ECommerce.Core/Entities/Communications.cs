namespace ECommerce.Core.Entities
{
    public class Communications : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public Customers Customer { get; set; }
    }
}
