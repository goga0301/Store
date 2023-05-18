using Banking.Domain.Entities;
using Banking.Infrastructure.Repository.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Infrastructure.Repository.Configurations
{
    public class CardConfiguration : BaseEntityConfiguration<Card, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Card> builder)
        {
            builder.Property(x => x.CardNumber).HasMaxLength(16).IsRequired();
            builder.Property(x => x.CardholderName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ExpirationDate).IsRequired();
            builder.Property(x => x.CvvCode).HasMaxLength(3).IsRequired();
            builder.Property(x => x.AccountId).IsRequired();
            builder.HasOne(x => x.Account).WithMany(x => x.Cards).HasForeignKey(x => x.AccountId);

            builder.HasIndex(x => x.CardNumber).IsUnique();

            
        }
    }
}
