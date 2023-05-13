using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Domain.Service.Domain;

namespace Store.Infrastructure.Service.Domain
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async void AddProduct(CreateProductModel product)
        {
            _productRepository.Create(product.MapForCreate());
            await _productRepository.SaveChangesAsync();
        }

        public async void DeleteProduct(int Id)
        {
            var product = await _productRepository.GetSingleAsync(x => x.Id == Id);
            if (product == null)
            {
                throw new Exception("პროდუქტი ვერ მოიძებნა");
            }

            _productRepository.SoftDelete(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId)
        {
            return (await _productRepository.GetAllAsync(x => x.ProductCategoryId == categoryId)).Select(x => x.Map());
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetSingleAsync(x => x.Id == id);
            if (product == null)
            {
                throw new Exception("პროდუქტი ვერ მოიძებნა");
            }
            return product.Map();
        }

        public async void UpdateProduct(UpdateProductModel productUpdate)
        {
            var product = await _productRepository.GetSingleAsync(x => x.Id == productUpdate.Id);
            if (product == null)
            {
                throw new Exception("პროდუქტი ვერ მოიძებნა");
            }

            product.Name = productUpdate.Name;
            product.Description = productUpdate.Description;
            product.Price = productUpdate.Price;
            product.ProductCategoryId = productUpdate.ProductCategoryId;
            product.ImageUrl = productUpdate.ImageUrl;
            product.Stock = productUpdate.Stock;

            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            return (await _productRepository.GetAllAsync()).Select(x => x.Map());
        }
    }
}
