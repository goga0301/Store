using Banking.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Entities.Base
{
    public abstract class BaseEntity<TKey> : IBaseEntity where TKey : struct
    {
        [Key]
        public TKey Id { get; set; }

        public RecordStatusEnum RecordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreateUserId { get; set; }

        public void Create(string createUserId)
        {
            RecordStatus = RecordStatusEnum.Active;
            CreateDate = DateTimeOffset.Now;
            CreateUserId = createUserId;
        }

    }

    public interface IBaseEntity : ISoftDeleteEntity
    {
    }

    public interface ISoftDeleteEntity
    {
        RecordStatusEnum RecordStatus { get; set; }
    }
}
