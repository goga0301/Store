using Store.Domain.Entities.Enums;


namespace Store.Domain.Entities.Base
{
    public interface ISoftDeleteEntity
    {
        RecordStatusEnum RecordStatus { get; set; }
    }
}
