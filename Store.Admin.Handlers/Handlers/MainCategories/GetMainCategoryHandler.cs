using MediatR;
using Store.Admin.Handlers.Queries.MainCategories;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Handlers.MainCategories
{
    public class GetMainCategoryHandler : IRequestHandler<GetMainCategoryQuery, IApiResponse<MainCategoryModel>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        public GetMainCategoryHandler(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }
        public async Task<IApiResponse<MainCategoryModel>> Handle(GetMainCategoryQuery request, CancellationToken cancellationToken)
        {
            var mainCategory = await _mainCategoryRepository.GetAsync(x => x.Id == request.Id);
            if (mainCategory == null)
            {
                throw new Exception("ძირითადი კატეგორია ვერ მოიძებნა");
            }
            return ApiResponse<MainCategoryModel>.Success(mainCategory.Map());
        }
    }
}
