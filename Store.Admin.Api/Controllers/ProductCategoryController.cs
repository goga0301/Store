using Microsoft.AspNetCore.Mvc;
using Store.Domain.Models.Domain;
using Store.Domain.Service.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ILogger<ProductCategoryController> _logger;
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService, ILogger<ProductCategoryController> logger)
        {
            _productCategoryService = productCategoryService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            var result = await _productCategoryService.GetProductCategoryByIdAsync(Id);
            return ApiResponse<ProductCategoryModel>.Success(result);
        }


        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            var result = await _productCategoryService.GetAllProductCategories();
            return ApiResponse<IEnumerable<ProductCategoryModel>>.Success(result);
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateProductCategoryModel product)
        {
            var Id = await _productCategoryService.AddProductCategory(product);
            return ApiResponse<int>.Success(Id, "პროდუქტის კატეგორია დაემატა");
        }

        [HttpPut("Update")]
        public Task<IApiResponse> Update([FromBody] UpdateProductCategoryModel product)
        {
            _productCategoryService.UpdateProductCategory(product);
            return Task.FromResult(ApiResponse.Success("პროდუქტის კატეგორიას კატეგორია განახლდა"));
        }

        [HttpDelete("Delete")]
        public Task<IApiResponse> Delete(int Id)
        {
            _productCategoryService.DeleteProductCategory(Id);
            return Task.FromResult(ApiResponse.Success("პროდუქტის კატეგორიას კატეგორია წაიშალა"));
        }

    }
}