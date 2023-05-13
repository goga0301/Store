using Microsoft.AspNetCore.Mvc;
using Store.Domain.Models.Domain;
using Store.Domain.Service.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            var result = await _productService.GetProductByIdAsync(Id);
            return ApiResponse<ProductModel>.Success(result);
        }


        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            var result = await _productService.GetAllProducts();
            return ApiResponse<IEnumerable<ProductModel>>.Success(result);
        }

        [HttpPost("Create")]
        public Task<IApiResponse> Create([FromBody] CreateProductModel product)
        {
            _productService.AddProduct(product);
            return Task.FromResult(ApiResponse.Success("პროდუქტი დაემატა"));
        }

        [HttpPut("Update")]
        public Task<IApiResponse> Update([FromBody] UpdateProductModel product)
        {
            _productService.UpdateProduct(product);
            return Task.FromResult(ApiResponse.Success("პროდუქტი განახლდა"));
        }

        [HttpDelete("Delete")]
        public Task<IApiResponse> Delete(int Id)
        {
            _productService.DeleteProduct(Id);
            return Task.FromResult(ApiResponse.Success("პროდუქტი წაიშალა"));
        }

    }
}

