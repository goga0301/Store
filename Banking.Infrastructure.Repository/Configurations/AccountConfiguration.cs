using Banking.Domain.Entities;
using Banking.Infrastructure.Repository.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Infrastructure.Repository.Configurations
{
    public class AccountConfiguration : BaseEntityConfiguration<Account, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.AccountNumber).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Balance).IsRequired();

            builder.HasMany(x => x.Cards).WithOne(x => x.Account).HasForeignKey(x => x.AccountId);
            
            builder.HasIndex(x => x.AccountNumber).IsUnique();

        }
    }
}
