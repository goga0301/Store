

using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Commands.ProductCategories
{
    public class DeleteProductCategoryCommand : IRequest<IApiResponse<bool>>
    {
        public DeleteProductCategoryModel Model { get; set; }
        public DeleteProductCategoryCommand(DeleteProductCategoryModel model)
        {
            Model = model;
        }
    }
}
