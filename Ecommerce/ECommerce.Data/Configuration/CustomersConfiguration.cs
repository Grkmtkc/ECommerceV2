using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerce.Data.Configuration
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(c => c.Id);

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

            builder.HasMany(c => c.Addresses)
                   .WithOne()
                   .HasForeignKey(a => a.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Communications)
                   .WithOne(c => c.Customer)
                   .HasForeignKey(c => c.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
