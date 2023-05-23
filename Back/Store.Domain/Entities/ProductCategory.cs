using Store.Domain.Entities.Base;
namespace Store.Domain.Entities
{
    public class ProductCategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int MainCategoryId { get; set; }
        public virtual MainCategory MainCategory { get; set; }
        public virtual IEnumerable<Product>? Products { get; set; }
    }
}
