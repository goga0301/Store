using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Commands.MainCategories
{
    public class UpdateMainCategoryCommand : IRequest<IApiResponse<bool>>
    {
        public UpdateMainCategoryModel Model { get; set; }
        public UpdateMainCategoryCommand(UpdateMainCategoryModel model)
        {
            Model = model;
        }
    }
}
