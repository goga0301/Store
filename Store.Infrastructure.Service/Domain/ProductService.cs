using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Domain.Service.Domain;
using System.Runtime.CompilerServices;

namespace Store.Infrastructure.Service.Domain
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async void AddProduct(Product product)
        {
            _productRepository.Create(product);
            await _productRepository.SaveChangesAsync();
        }

        public async void DeleteProduct(Product product)
        {
            _productRepository.SoftDelete(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(int categoryId)
        {
            return await _productRepository.GetAllAsync(x => x.ProductCategoryId == categoryId);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetSingleAsync(x => x.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
