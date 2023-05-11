using Store.Domain.Entities;
using Store.Domain.Service.Domain.Base;

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
