using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Admin.Handlers.Commands.Products;
using Store.Admin.Handlers.Queries.Products;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            return await _mediator.Send(new GetProductQuery(Id));
        }


        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            return await _mediator.Send(new GetProductsQuery());
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateProductModel product)
        {
            return await _mediator.Send(new CreateProductCommand(product));
        }

        [HttpPut("Update")]
        public async Task<IApiResponse> Update([FromBody] UpdateProductModel product)
        {
            return await _mediator.Send(new UpdateProductCommand(product));
        }
         
        [HttpDelete("Delete")]
        public async Task<IApiResponse> Delete([FromBody] DeleteProductModel product)
        {
            return await _mediator.Send(new DeleteProductCommand(product));
        }
        
    }
}