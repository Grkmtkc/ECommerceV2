using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Configuration
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.SaleDate)
                   .IsRequired();

            builder.Property(s => s.Quantity)
                   .IsRequired();

            builder.Property(s => s.TotalAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasOne(s => s.Customer)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Product)
                   .WithMany(p => p.Sales)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
