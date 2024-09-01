namespace ECommerce.Core.Entities
{
    public class Addresses : BaseEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public Customers Customer { get; set; }
    }
}
