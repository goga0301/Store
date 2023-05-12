using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

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
