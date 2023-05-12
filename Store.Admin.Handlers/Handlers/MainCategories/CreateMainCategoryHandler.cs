using MediatR;
using Store.Admin.Handlers.Commands.MainCategories;
using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.MainCategories
{
    public class CreateMainCategoryHandler : IRequestHandler<CreateMainCategoryCommand, IApiResponse<int>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        public CreateMainCategoryHandler(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }
        public async Task<IApiResponse<int>> Handle(CreateMainCategoryCommand request, CancellationToken cancellationToken)
        {
            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var mainCategory = new MainCategory
                {
                    Name = request.Model.Name,
                    Description = request.Model.Description

                };
                _mainCategoryRepository.Create(mainCategory);
                await _mainCategoryRepository.SaveChangesAsync();
                scope.Complete();
                return ApiResponse<int>.Success(mainCategory.Id, "ძირითადი კატეგორია წარმატებით შეიქმნა");
            }
        }
    }
}
