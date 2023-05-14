using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Domain.Entities.Base;
using Banking.Domain.Entities.Enums;

namespace Banking.Infrastructure.Repository.Configurations.Base
{
    public abstract class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            if (typeof(TKey) == typeof(Guid) || typeof(TKey).IsEnum)
            {
                builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedNever();
            }
            else
            {
                builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            }

            ConfigureEntity(builder);

            builder.Property(x => x.RecordStatus).HasColumnName("RecordStatus").IsRequired();
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate").IsRequired();
            builder.Property(x => x.CreateUserId).HasColumnName("CreateUserId").HasColumnType("varchar").HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.RecordStatus);

            //global query filter for ISoftDelete entity
            builder.HasQueryFilter(x => x.RecordStatus == RecordStatusEnum.Active);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}
