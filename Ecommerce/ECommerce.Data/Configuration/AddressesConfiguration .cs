using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerce.Data.Configuration
{
    public class AddressesConfiguration : IEntityTypeConfiguration<Addresses>
    {
        public void Configure(EntityTypeBuilder<Addresses> builder)
        {
            // Primary Key
            builder.HasKey(a => a.Id);

            // Property configurations
            builder.Property(a => a.Adress)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(a => a.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Country)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.IsActive)
                   .HasDefaultValue(true);

            builder.Property(a => a.IsDeleted)
                   .HasDefaultValue(false);

            // Relationship configuration
            builder.HasOne(a => a.Customer)
                   .WithMany(c => c.Addresses) // Customers tablosunda Addresses koleksiyonuna referans verir.
                   .HasForeignKey(a => a.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
