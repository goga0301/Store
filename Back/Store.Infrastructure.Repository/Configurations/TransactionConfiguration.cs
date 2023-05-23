using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.Infrastructure.Repository.Configurations.Base;

namespace Store.Infrastructure.Repository.Configurations
{
    public class TransactionConfiguration : BaseEntityConfiguration<Transaction, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.CardId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne<Order>().WithMany().HasForeignKey(x => x.OrderId);
            builder.HasOne<Customer>().WithMany().HasForeignKey(x => x.CustomerId);
            builder.HasOne<Card>().WithMany().HasForeignKey(x => x.CardId);

            builder.HasIndex(x => x.OrderId);
            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.CardId);
            builder.HasIndex(x => x.Status);
        }
    }
}
