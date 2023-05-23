

using MediatR;
using Store.Admin.Handlers.Queries.ProductCategories;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Shared.Helpers;

namespace Store.Admin.Handlers.Handlers.ProductCategories
{
    public class GetProductCategoryHandler : IRequestHandler<GetProductCategoryQuery, IApiResponse<ProductCategoryModel>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public GetProductCategoryHandler(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task<IApiResponse<ProductCategoryModel>> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetAsync(x => x.Id == request.Id);
            if (productCategory == null)
            {
                throw new Exception("პროდუქტი ვერ მოიძებნა");
            }
            return ApiResponse<ProductCategoryModel>.Success(productCategory.Map());
        }
    }
}
