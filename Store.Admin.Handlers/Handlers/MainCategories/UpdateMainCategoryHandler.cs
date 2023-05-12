using MediatR;
using Store.Admin.Handlers.Commands.MainCategories;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.MainCategories
{
    public class UpdateMainCategoryHandler : IRequestHandler<UpdateMainCategoryCommand, IApiResponse<bool>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        public UpdateMainCategoryHandler(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }
        public async Task<IApiResponse<bool>> Handle(UpdateMainCategoryCommand request, CancellationToken cancellationToken)
        {

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var mainCategory = await _mainCategoryRepository.GetAsync(x => x.Id == request.Model.Id);
                if (mainCategory == null)
                {
                    throw new Exception("ძირითადი კატეგორია ვერ მოიძებნა");
                }
                mainCategory.Name = request.Model.Name;
                mainCategory.Description = request.Model.Description;
                _mainCategoryRepository.Update(mainCategory);
                await _mainCategoryRepository.SaveChangesAsync();
                scope.Complete();
                return ApiResponse<bool>.Success(true, "ძირითადი კატეგორია წარმატებით განახლდა");
            }
        }
    }
}
