using Banking.Domain.Entities;
using Banking.Infrastructure.Repository.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Infrastructure.Repository.Configurations
{
    public class CardConfiguration : BaseEntityConfiguration<Card, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Card> builder)
        {
            
        }
    }
}
