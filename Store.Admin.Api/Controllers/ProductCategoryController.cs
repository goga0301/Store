using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Admin.Handlers.Commands.ProductCategories;
using Store.Admin.Handlers.Queries.ProductCategories;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ILogger<ProductCategoryController> _logger;
        private readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator, ILogger<ProductCategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            return await _mediator.Send(new GetProductCategoryQuery(Id));
        }



        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            return await _mediator.Send(new GetProductCategoriesQuery());
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateProductCategoryModel productCategory)
        {
            
            return await _mediator.Send(new CreateProductCategoryCommand(productCategory));
        }

        [HttpPut("Update")]
        public async Task<IApiResponse> Update([FromBody] UpdateProductCategoryModel productCategory)
        {
            return await _mediator.Send(new UpdateProductCategoryCommand(productCategory));
        }

        [HttpDelete("Delete")]
        public async Task<IApiResponse> Delete([FromBody] DeleteProductCategoryModel productCategory)
        {
            return await _mediator.Send(new DeleteProductCategoryCommand(productCategory));
        }
        
    }
}