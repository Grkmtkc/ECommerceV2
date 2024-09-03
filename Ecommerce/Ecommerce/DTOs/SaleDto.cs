namespace ECommerce.API.DTOs
{
    public class SaleDto : BaseEntityDto
    {
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<CustomerDto>? Customers { get; set; }
        public ICollection<ProductDto>? Products { get; set; }
    }
}
