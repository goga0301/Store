using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Commands.MainCategories
{
    public class CreateMainCategoryCommand : IRequest<IApiResponse<int>>
    {
        public CreateMainCategoryModel Model { get; set; }
        public CreateMainCategoryCommand(CreateMainCategoryModel model)
        {
            Model = model;
        }

    }
}
