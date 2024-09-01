using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerce.Data.Configuration
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            // Primary Key
            builder.HasKey(c => c.Id);

            // Property configurations
            builder.Property(c => c.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.Age)
                   .IsRequired();

            builder.Property(c => c.Birthday)
                   .IsRequired();

            builder.Property(c => c.RegistrationDate)
                   .HasDefaultValue(DateTime.UtcNow);

            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);

            builder.Property(c => c.IsDeleted)
                   .HasDefaultValue(false);

            // Relationship with Addresses
            builder.HasMany(c => c.Addresses)
                   .WithOne(a => a.Customer) // Addresses tablosundaki Customer navigasyon özelliği
                   .HasForeignKey(a => a.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relationship with Communications
            builder.HasMany(c => c.Communications)
                   .WithOne(cm => cm.Customer) // Communications tablosundaki Customer navigasyon özelliği
                   .HasForeignKey(cm => cm.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
