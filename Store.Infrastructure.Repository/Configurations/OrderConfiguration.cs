using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.Infrastructure.Repository.Configurations.Base;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Store.Infrastructure.Repository.Configurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order, int>
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        public override void ConfigureEntity(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.AddressId).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.TransactionId);
            builder.Property(x => x.OrderItems).HasColumnType("nclob").HasConversion(
                        x => JsonSerializer.Serialize(x, _jsonOptions),
                        y => JsonSerializer.Deserialize<IEnumerable<OrderItem>>(y, _jsonOptions)!);

            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.Address).WithMany().HasForeignKey(x => x.AddressId);

            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.Status);
        }
    }
}
