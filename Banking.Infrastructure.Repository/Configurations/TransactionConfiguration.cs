using Banking.Domain.Entities;
using Banking.Infrastructure.Repository.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Infrastructure.Repository.Configurations
{
    public class TransactionConfiguration : BaseEntityConfiguration<Transaction, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(x => x.CardId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.TransactionStatus).IsRequired();
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.ExternalId).IsRequired();

            builder.HasOne(x => x.Card)
                .WithMany()
                .HasForeignKey(x => x.CardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.CardId);
        }
    }
}
