using Microsoft.AspNetCore.Mvc;
using Store.Domain.Models.Domain;
using Store.Domain.Service.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainCategoryController : ControllerBase
    {
        private readonly ILogger<MainCategoryController> _logger;
        private readonly IMainCategoryService _mainCategoryService;

        public MainCategoryController(IMainCategoryService mainCategoryService, ILogger<MainCategoryController> logger)
        {
            _mainCategoryService = mainCategoryService;
            _logger = logger;
        }
        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            var result = await _mainCategoryService.GetMainCategoryByIdAsync(Id);
            return ApiResponse<MainCategoryModel>.Success(result);
        }


        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            var result = await _mainCategoryService.GetAllMainCategories();
            return ApiResponse<IEnumerable<MainCategoryModel>>.Success(result);
        }

        [HttpPost("Create")]
        public Task<IApiResponse> Create([FromBody] CreateMainCategoryModel main)
        {
            _mainCategoryService.AddMainCategory(main);
            return Task.FromResult(ApiResponse.Success("ძირითადი კატეგორია დაემატა"));
        }

        [HttpPut("Update")]
        public Task<IApiResponse> Update([FromBody] UpdateMainCategoryModel main)
        {
            _mainCategoryService.UpdateMainCategory(main);
            return Task.FromResult(ApiResponse.Success("ძირითადი კატეგორიას კატეგორია განახლდა"));
        }

        [HttpDelete("Delete")]
        public Task<IApiResponse> Delete(int Id)
        {
            _mainCategoryService.DeleteMainCategory(Id);
            return Task.FromResult(ApiResponse.Success("ძირითადი კატეგორიას კატეგორია წაიშალა"));
        }
    }
}