using Store.Domain.Entities;

namespace Store.Domain.Service.Domain
{
    public interface IProductCategoryService 
    {
        void AddProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(ProductCategory productCategory);
        Task<ProductCategory?> GetProductCategoryByIdAsync(int id);
        Task<IEnumerable<ProductCategory>> GetAllProductCategories();
    }
}
