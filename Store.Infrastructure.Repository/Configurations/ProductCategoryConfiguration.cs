using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.Infrastructure.Repository.Configurations.Base;
namespace Store.Infrastructure.Repository.Configurations
{
    public class ProductCategoryConfiguration : BaseEntityConfiguration<ProductCategory, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(1000);

        }
    }
}
