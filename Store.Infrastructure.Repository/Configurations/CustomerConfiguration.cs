using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.Infrastructure.Repository.Configurations.Base;

namespace Store.Infrastructure.Repository.Configurations
{
    public class CustomerConfiguration : BaseEntityConfiguration<Customer, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Address).HasColumnName("Address").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.UserName).HasColumnName("UserName").HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Gender).HasColumnName("Gender").HasColumnType("int").HasMaxLength(2).IsRequired();
            builder.Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired();

            builder.HasIndex(x => x.UserName).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.PhoneNumber);


        }
    }
}
