using Store.Domain.Models.Domain;

namespace Store.Domain.Service.Domain
{
    public interface IProductCategoryService 
    {
        void AddProductCategory(CreateProductCategoryModel productCategory);
        void UpdateProductCategory(UpdateProductCategoryModel productCategory);
        void DeleteProductCategory(int Id);
        Task<ProductCategoryModel> GetProductCategoryByIdAsync(int id);
        Task<IEnumerable<ProductCategoryModel>> GetAllProductCategories();
    }
}
