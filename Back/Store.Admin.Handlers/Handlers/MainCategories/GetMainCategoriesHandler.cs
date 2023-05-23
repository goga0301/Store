using MediatR;
using Store.Admin.Handlers.Queries.MainCategories;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Shared.Helpers;

namespace Store.Admin.Handlers.Handlers.MainCategories
{
    public class GetMainCategoriesHandler : IRequestHandler<GetMainCategoriesQuery, IApiResponse<IEnumerable<MainCategoryModel>>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        public GetMainCategoriesHandler(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }
        public async Task<IApiResponse<IEnumerable<MainCategoryModel>>> Handle(GetMainCategoriesQuery request, CancellationToken cancellationToken)
        {
            var mainCategories = await _mainCategoryRepository.GetAllAsync();
            return ApiResponse<IEnumerable<MainCategoryModel>>.Success(mainCategories.Select(x => x.Map()));
        }
    }
}
