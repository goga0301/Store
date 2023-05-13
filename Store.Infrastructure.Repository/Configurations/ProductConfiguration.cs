using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.Infrastructure.Repository.Configurations.Base;

namespace Store.Infrastructure.Repository.Configurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar").HasMaxLength(90).IsRequired();
            builder.Property(x => x.Price).HasColumnName("Price").HasMaxLength(9).IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar").HasMaxLength(500); 
            builder.Property(x => x.Stock).HasColumnName("Stock").IsRequired();
            builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl").HasColumnType("varchar").HasMaxLength(500);

            builder.HasOne(x => x.ProductCategory).WithMany(x => x.Products).HasForeignKey(x => x.ProductCategoryId);

            builder.HasIndex(x => x.ProductCategoryId);
        }
    }
}
