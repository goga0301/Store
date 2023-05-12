using MediatR;
using Store.Admin.Handlers.Commands.Products;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, IApiResponse<bool>>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IApiResponse<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var item = await _productRepository.GetAsync(x => x.Id == request.Model.Id);
                if (item == null)
                {
                    throw new Exception("პროდუქტი ვერ მოიძებნა");
                }
                item.Name = request.Model.Name;
                item.Description = request.Model.Description;
                item.Price = request.Model.Price;
                item.ProductCategoryId = request.Model.ProductCategoryId;
                item.ImageUrl = request.Model.ImageUrl;
                item.Stock = request.Model.Stock;

                _productRepository.Update(item);
                await _productRepository.SaveChangesAsync();
                scope.Complete();
                return ApiResponse<bool>.Success(true, "პროდუქტი წარმატებით განახლდა");
            }


        }
    }
}
