using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Commands.Products
{
    public class UpdateProductCommand : IRequest<IApiResponse<bool>>
    {
        public UpdateProductModel Model { get; set; }
        public UpdateProductCommand(UpdateProductModel model)
        {
            Model = model;
        }
    }
}
