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
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar").HasMaxLength(90).IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar").HasMaxLength(300);
            builder.Property(x => x.MainCategoryId).HasColumnName("MainCategoryId").IsRequired();

            builder.HasOne(x => x.MainCategory).WithMany(x => x.ProductCategories).HasForeignKey(x => x.MainCategoryId);

            builder.HasIndex(x => x.MainCategoryId);

        }
    }
}
