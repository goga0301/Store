using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.Infrastructure.Repository.Configurations.Base;

namespace Store.Infrastructure.Repository.Configurations
{
    public class AddressConfiguration : BaseEntityConfiguration<Address, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.StreetAddress).HasMaxLength(100).IsRequired();
            builder.Property(x => x.City).HasMaxLength(50).IsRequired();
            builder.Property(x => x.StateOrProvince).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PostalCode).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Building).HasMaxLength(50);
            builder.Property(x => x.Floor).HasMaxLength(50);

            builder.HasOne(x => x.Customer).WithMany(x => x.Addresses).HasForeignKey(x => x.CustomerId);

            builder.HasIndex(x => x.PostalCode);
            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.City);
            builder.HasIndex(x => x.StateOrProvince);
            builder.HasIndex(x => x.Country);

        }
    }
}
