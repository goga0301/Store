using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Commands.Addresses
{
    public class UpdateAddressCommand : IRequest<IApiResponse<bool>>
    {
        public UpdateAddressModel Model { get; set; }
        public UpdateAddressCommand(UpdateAddressModel model)
        {
            Model = model;
        }
    }
}
