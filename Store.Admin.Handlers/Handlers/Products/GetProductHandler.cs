using MediatR;
using Store.Admin.Handlers.Queries.Products;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Handlers.Products
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, IApiResponse<ProductModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IApiResponse<ProductModel>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await  _productRepository.GetAsync(x => x.Id == request.Id);
            if (product == null)
            {
                throw new Exception("პროდუქტი ვერ მოიძებნა");
            }
            return ApiResponse<ProductModel>.Success(product.Map());
        }
    }
}
