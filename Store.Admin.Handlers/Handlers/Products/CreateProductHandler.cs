using MediatR;
using Store.Admin.Handlers.Commands.Products;
using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, IApiResponse<int>>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IApiResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var product = new Product
                {
                    Name = request.Model.Name,
                    Description = request.Model.Description,
                    Price = request.Model.Price,
                    Stock = request.Model.Stock,
                    ImageUrl = request.Model.ImageUrl,
                    ProductCategoryId = request.Model.ProductCategoryId,
                    RecordStatus = RecordStatusEnum.Active,
                    CreateDate = DateTime.Now,
                    CreateUserId = "test"

                };
                await _productRepository.CreateAsync(product);
                scope.Complete();
                return ApiResponse<int>.Success(product.Id, "პროდუქტი წარმატებით შეიქმნა");
            }
        }
    }
}
