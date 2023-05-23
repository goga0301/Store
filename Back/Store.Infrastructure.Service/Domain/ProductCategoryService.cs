using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
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

        public async Task<int> AddProductCategory(CreateProductCategoryModel productCategory)
        {
            return await _productCategoryRepository.CreateAsync(productCategory.Map());
            
        }

        public async void DeleteProductCategory(int Id)
        {
            var productCategory = await _productCategoryRepository.GetSingleAsync(x => x.Id == Id);
            if (productCategory == null)
            {
                throw new Exception("პროდუქტის კატეგორია ვერ მოიძებნა");
            }
            _productCategoryRepository.SoftDelete(productCategory);
            await _productCategoryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategoryModel>> GetAllProductCategories()
        {
            return (await _productCategoryRepository.GetAllAsync(i => i.Products)).Select(x => x.Map());
        }

        public async Task<ProductCategoryModel> GetProductCategoryByIdAsync(int id)
        {
            var productCategory = await _productCategoryRepository.GetSingleAsync(x => x.Id == id, i => i.Products);
            if (productCategory == null)
            {
                throw new Exception("პროდუქტის კატეგორია ვერ მოიძებნა");
            }
            return productCategory.Map();
        }

        public async void UpdateProductCategory(UpdateProductCategoryModel productCategory)
        {
            var category = await _productCategoryRepository.GetSingleAsync(x => x.Id == productCategory.Id );
            if (category == null)
            {
                throw new Exception("პროდუქტის კატეგორია ვერ მოიძებნა");
            }
            category.Name = productCategory.Name;
            category.Description = productCategory.Description;
            category.MainCategoryId = productCategory.MainCategoryId;

            _productCategoryRepository.Update(category);
            await _productCategoryRepository.SaveChangesAsync();
        }
    }
}
