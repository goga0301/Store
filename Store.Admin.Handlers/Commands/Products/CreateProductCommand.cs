
using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Commands.Products
{
    public class CreateProductCommand : IRequest<IApiResponse<int>>
    {
        public CreateProductModel Model { get; set; }
        public CreateProductCommand(CreateProductModel model)
        {
            Model = model;
        }
   }
}
