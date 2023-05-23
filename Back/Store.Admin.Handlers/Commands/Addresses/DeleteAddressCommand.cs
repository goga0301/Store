using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Commands.Addresses
{
    public class DeleteAddressCommand : IRequest<IApiResponse<bool>>
    {
        public DeleteAddressModel Model { get; set; }
        public DeleteAddressCommand(DeleteAddressModel model)
        {
            Model = model;
        }
    }
}
