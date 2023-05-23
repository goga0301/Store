using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.Infrastructure.Repository.Configurations.Base;

namespace Store.Infrastructure.Repository.Configurations
{
    public class CardConfiguration : BaseEntityConfiguration<Card, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Card> builder)
        {
            builder.Property(x => x.CardNumber).HasMaxLength(16).IsRequired();
            builder.Property(x => x.CardholderName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ExpirationDate).IsRequired();
            builder.Property(x => x.CvvCode).HasMaxLength(3).IsRequired();
            builder.Property(x => x.CardType).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();

            builder.HasOne(x => x.Customer).WithMany(x => x.Cards).HasForeignKey(x => x.CustomerId);


            builder.HasIndex(x => x.CardNumber).IsUnique();
            builder.HasIndex(x => x.CardholderName);
            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.CardType);
        }
    }
}
