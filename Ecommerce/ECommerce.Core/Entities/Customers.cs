namespace ECommerce.Core.Entities
{
    public class Customers : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public ICollection<Addresses> Addresses { get; set; }
        public ICollection<Communications> Communications { get; set; }
        public ICollection<Sales> Sales { get; set; }
    }
}
