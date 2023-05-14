using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Commands.Customers
{
    public class UpdateCustomerCommand : IRequest<IApiResponse<bool>>
    {
        public UpdateCustomerModel Model { get; set; }
        public UpdateCustomerCommand(UpdateCustomerModel model)
        {
            Model = model;
        }
    }
}
