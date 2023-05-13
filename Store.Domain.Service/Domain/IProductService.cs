
using Store.Domain.Models.Domain;

namespace Store.Domain.Service.Domain
{
    public interface IProductService 
    {
        void AddProduct(CreateProductModel product);
        void UpdateProduct(UpdateProductModel product);
        void DeleteProduct(int Id);
        Task<ProductModel> GetProductByIdAsync(int Id);
        Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId);
        Task<IEnumerable<ProductModel>> GetAllProducts();

    }
}
