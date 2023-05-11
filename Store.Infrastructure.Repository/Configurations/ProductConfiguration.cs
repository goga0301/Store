using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.Infrastructure.Repository.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Repository.Configurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Price).HasColumnName("Price").HasMaxLength(9).IsRequired();
            builder.Property(x=> x.Description).HasColumnName("Description").HasMaxLength(1000); 
            builder.Property(x => x.Stock).HasColumnName("Stock").IsRequired();
            builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl").HasMaxLength(1000);

            builder.HasOne(x => x.ProductCategory).WithMany().HasForeignKey(x => x.ProductCategoryId);

            builder.HasIndex(x => x.ProductCategoryId);
        }
    }
}
