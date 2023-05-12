using MediatR;
using Store.Admin.Handlers.Queries.ProductCategories;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Handlers.ProductCategories
{
    public class GetProductCategoriesHandler : IRequestHandler<GetProductCategoriesQuery, IApiResponse<IEnumerable<ProductCategoryModel>>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public GetProductCategoriesHandler(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task<IApiResponse<IEnumerable<ProductCategoryModel>>> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var products= await _productCategoryRepository.GetAllAsync();
          
            return ApiResponse<IEnumerable<ProductCategoryModel>>.Success(products.Select(x => x.Map()));
        }
    }
}
