using Store.Domain.Entities.Base;

namespace Store.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
