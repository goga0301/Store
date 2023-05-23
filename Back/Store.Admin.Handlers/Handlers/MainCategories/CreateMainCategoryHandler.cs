using MediatR;
using Store.Admin.Handlers.Commands.MainCategories;
using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Repository;
using Shared.Helpers;
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
                    Description = request.Model.Description,
                    RecordStatus = RecordStatusEnum.Active,
                    CreateDate = DateTime.Now,
                    CreateUserId = "test"
                    
                };
                await _mainCategoryRepository.CreateAsync(mainCategory);
                scope.Complete();
                return ApiResponse<int>.Success(mainCategory.Id, "ძირითადი კატეგორია წარმატებით შეიქმნა");
            }
        }
    }
}
