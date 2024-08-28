using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerce.Data.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProductName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasMaxLength(500);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.StockQuantity)
                   .IsRequired();

            builder.Property(p => p.CreatedDate)
                   .HasDefaultValue(DateTime.UtcNow);

            builder.Property(p => p.IsActive)
                   .HasDefaultValue(true);

            builder.Property(p => p.IsDeleted)
                   .HasDefaultValue(false);

            builder.HasMany(p => p.Sales)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
