using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Commands.Customers
{
    public class CreateCustomerCommand : IRequest<IApiResponse<int>>
    {
        public CreateCustomerModel Model { get; set; }
        public CreateCustomerCommand(CreateCustomerModel model)
        {
            Model = model;
        }
    }
}
