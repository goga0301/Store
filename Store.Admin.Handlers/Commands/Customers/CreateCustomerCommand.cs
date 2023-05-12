using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
