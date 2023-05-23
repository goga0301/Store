
using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Commands.ProductCategories
{
    public class CreateProductCategoryCommand : IRequest<IApiResponse<int>>
    {
        public CreateProductCategoryModel Model { get; set; }
        public CreateProductCategoryCommand(CreateProductCategoryModel model)
        {
            Model = model;
        }
   }
}
