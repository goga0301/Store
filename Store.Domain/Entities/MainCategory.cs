using Store.Domain.Entities.Base;
namespace Store.Domain.Entities
{
    public class MainCategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
