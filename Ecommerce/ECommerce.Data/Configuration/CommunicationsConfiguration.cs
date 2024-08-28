using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Configuration
{
    public class CommunicationsConfiguration : IEntityTypeConfiguration<Communications>
    {
        public void Configure(EntityTypeBuilder<Communications> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                   .HasMaxLength(20);

            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);

            builder.Property(c => c.IsDeleted)
                   .HasDefaultValue(false);

            builder.HasOne(c => c.Customer)
                   .WithMany()
                   .HasForeignKey(c => c.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
