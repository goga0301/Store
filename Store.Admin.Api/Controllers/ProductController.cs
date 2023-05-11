using Microsoft.AspNetCore.Mvc;
using Store.Domain.Entities;
using Store.Domain.Service.Domain;

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
        public async Task<Product> Get(int Id)
        {
            return await _productService.GetProductByIdAsync(Id);
        }

        [HttpGet("GetByCategory")]
        public async Task<IEnumerable<Product>> GetByCategory(int categoryId)
        {
            return await _productService.GetProductByCategory(categoryId);
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productService.GetAllProducts();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Product product)
        {
            _productService.UpdateProduct(product);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Product product)
        {
            _productService.DeleteProduct(product);
            return Ok();
        }
        
    }
}