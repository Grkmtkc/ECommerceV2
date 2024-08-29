namespace ECommerce.API.DTOs
{
    public class ProductDto : BaseEntityDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<SaleDto> Sales { get; set; }
    }
}
