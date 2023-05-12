using MediatR;
using Store.Admin.Handlers.Queries.Products;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Handlers.Products
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IApiResponse<IEnumerable<ProductModel>>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IApiResponse<IEnumerable<ProductModel>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products= await _productRepository.GetAllAsync();
          
            return ApiResponse<IEnumerable<ProductModel>>.Success(products.Select(x => x.Map()));
        }
    }
}
