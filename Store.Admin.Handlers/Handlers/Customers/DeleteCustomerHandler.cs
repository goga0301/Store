using MediatR;
using Store.Admin.Handlers.Commands.Customers;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.Customers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, IApiResponse<bool>>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IApiResponse<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var customer = await _customerRepository.GetAsync(x => x.Id == request.Model.Id);
                if(customer == null)
                {
                    throw new Exception("კლიენტი ვერ მოიძებნა");
                }
                _customerRepository.SoftDelete(customer);
                scope.Complete();
                return ApiResponse<bool>.Success(true, "კლიენტი წაიშალა");
            }
        }
    }
}
