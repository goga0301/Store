using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.Infrastructure.Repository.Configurations.Base;

namespace Store.Infrastructure.Repository.Configurations
{
    public class MainCategoryConfiguration : BaseEntityConfiguration<MainCategory, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<MainCategory> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar").HasMaxLength(90).IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar").HasMaxLength(300);
        
        }
    }
}
