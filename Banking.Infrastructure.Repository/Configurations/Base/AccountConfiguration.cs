using Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Infrastructure.Repository.Configurations.Base
{
    public class AccountConfiguration : BaseEntityConfiguration<Account, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Account> builder)
        {

        }
    }
}
