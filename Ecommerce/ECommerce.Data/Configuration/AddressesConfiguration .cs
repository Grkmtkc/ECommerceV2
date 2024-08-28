using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerce.Data.Configuration
{
    public class AddressesConfiguration : IEntityTypeConfiguration<Addresses>
    {
        public void Configure(EntityTypeBuilder<Addresses> builder)
        {

            builder.HasKey(a => a.Id);

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

            builder.HasOne(c => c.Customer)
                   .WithMany()
                   .HasForeignKey(c => c.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
