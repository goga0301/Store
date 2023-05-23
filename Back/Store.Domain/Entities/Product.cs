using Store.Domain.Entities.Base;

namespace Store.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        

    }
}
