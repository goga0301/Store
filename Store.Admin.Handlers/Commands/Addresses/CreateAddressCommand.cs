using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Commands.Addresses
{
    public class CreateAddressCommand : IRequest<IApiResponse<int>>
    {
        public CreateAddressModel Model { get; set; }
        public CreateAddressCommand(CreateAddressModel model)
        {
            Model = model;
        }
    }
}
