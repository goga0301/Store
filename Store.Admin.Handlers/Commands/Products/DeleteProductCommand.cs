

using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Commands.Products
{
    public class DeleteProductCommand : IRequest<IApiResponse<bool>>
    {
        public DeleteProductModel Model { get; set; }
        public DeleteProductCommand(DeleteProductModel model)
        {
            Model = model;
        }
    }
}
