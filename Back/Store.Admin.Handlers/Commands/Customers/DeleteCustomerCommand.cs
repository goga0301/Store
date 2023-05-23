using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Commands.Customers
{
    public class DeleteCustomerCommand  : IRequest<IApiResponse<bool>>
    {
        public DeleteCustomerModel Model { get; set; }
        public DeleteCustomerCommand(DeleteCustomerModel model)
        {
            Model = model;
        }
    }
}
