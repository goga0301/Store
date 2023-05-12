using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Commands.MainCategories
{
    public class DeleteMainCategoryCommand : IRequest<IApiResponse<bool>>
    {
        public DeleteMainCategoryModel Model { get; set; }
        public DeleteMainCategoryCommand(DeleteMainCategoryModel model)
        {
            Model = model;
        }
    }
}
