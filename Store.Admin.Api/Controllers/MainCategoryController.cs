using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Admin.Handlers.Commands.MainCategories;
using Store.Admin.Handlers.Queries.MainCategories;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainCategoryController : ControllerBase
    {
        private readonly ILogger<MainCategoryController> _logger;
        private readonly IMediator _mediator;

        public MainCategoryController(IMediator mediator, ILogger<MainCategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            return await _mediator.Send(new GetMainCategoryQuery(Id));
        }



        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            return await _mediator.Send(new GetMainCategoriesQuery());
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateMainCategoryModel MainCategory)
        {

            return await _mediator.Send(new CreateMainCategoryCommand(MainCategory));
        }

        [HttpPut("Update")]
        public async Task<IApiResponse> Update([FromBody] UpdateMainCategoryModel MainCategory)
        {
            return await _mediator.Send(new UpdateMainCategoryCommand(MainCategory));
        }

        [HttpDelete("Delete")]
        public async Task<IApiResponse> Delete([FromBody] DeleteMainCategoryModel MainCategory)
        {
            return await _mediator.Send(new DeleteMainCategoryCommand(MainCategory));
        }
    }
}