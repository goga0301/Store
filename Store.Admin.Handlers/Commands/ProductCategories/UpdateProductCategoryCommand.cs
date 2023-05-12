using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Commands.ProductCategories
{
    public class UpdateProductCategoryCommand : IRequest<IApiResponse<bool>>
    {
        public UpdateProductCategoryModel Model { get; set; }
        public UpdateProductCategoryCommand(UpdateProductCategoryModel model)
        {
            Model = model;
        }
    }
}
