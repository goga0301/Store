using Microsoft.AspNetCore.Mvc;
using Store.Domain.Entities;
using Store.Domain.Service.Domain;

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
        public async Task<ProductCategory> Get(int Id)
        {
            return await _productCategoryService.GetProductCategoryByIdAsync(Id);
        }



        [HttpGet("GetAll")]
        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            return await _productCategoryService.GetAllProductCategories();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] ProductCategory productCategory)
        {
            _productCategoryService.AddProductCategory(productCategory);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] ProductCategory productCategory)
        {
            _productCategoryService.UpdateProductCategory(productCategory);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] ProductCategory productCategory)
        {
            _productCategoryService.DeleteProductCategory(productCategory);
            return Ok();
        }
        
    }
}