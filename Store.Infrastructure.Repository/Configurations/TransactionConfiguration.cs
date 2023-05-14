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
    public class TransactionConfiguration : BaseEntityConfiguration<Transaction, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.CardId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne<Order>().WithOne().HasForeignKey<Transaction>(x => x.OrderId);
            builder.HasOne<Customer>().WithOne().HasForeignKey<Transaction>(x => x.CustomerId);
            builder.HasOne<Card>().WithOne().HasForeignKey<Transaction>(x => x.CardId);

            builder.HasIndex(x => x.OrderId);
            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.CardId);
            builder.HasIndex(x => x.Status);
        }
    }
}
