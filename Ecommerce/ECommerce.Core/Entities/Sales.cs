namespace ECommerce.Core.Entities
{
    public class Sales : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
