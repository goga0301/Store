using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Domain.Service.Domain;

namespace Store.Infrastructure.Service.Domain
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async void AddProductCategory(ProductCategory productCategory)
        {
            _productCategoryRepository.Create(productCategory);
            await _productCategoryRepository.SaveChangesAsync();
        }

        public async void DeleteProductCategory(ProductCategory productCategory)
        {
            _productCategoryRepository.SoftDelete(productCategory);
            await _productCategoryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategories()
        {
            return await _productCategoryRepository.GetAllAsync();
        }

        public async Task<ProductCategory?> GetProductCategoryByIdAsync(int id)
        {
            return await _productCategoryRepository.GetSingleAsync(x => x.Id == id);
        }

        public async void UpdateProductCategory(ProductCategory productCategory)
        {
            _productCategoryRepository.Update(productCategory);
            await _productCategoryRepository.SaveChangesAsync();
        }
    }
}
