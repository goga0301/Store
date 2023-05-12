using MediatR;
using Store.Admin.Handlers.Commands.MainCategories;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.MainCategories
{
    public class DeleteMainCategoryHandler : IRequestHandler<DeleteMainCategoryCommand, IApiResponse<bool>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        public DeleteMainCategoryHandler(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<IApiResponse<bool>> Handle(DeleteMainCategoryCommand request, CancellationToken cancellationToken)
        {
            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var item = await _mainCategoryRepository.GetAsync(x => x.Id == request.Model.Id);
                if (item == null)
                    throw new Exception("ძირითადი კატეგორია ვერ მოიძებნა");

                _mainCategoryRepository.SoftDelete(item);
                await _mainCategoryRepository.SaveChangesAsync();
                scope.Complete();
             
                return ApiResponse<bool>.Success(true, "ძირითადი კატეგორია წარმატებით წაიშალა");
            }
        }
    }
}
