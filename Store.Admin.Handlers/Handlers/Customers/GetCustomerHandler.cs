using MediatR;
using Store.Admin.Handlers.Queries.Customers;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Handlers.Customers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, IApiResponse<CustomerModel>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IApiResponse<CustomerModel>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == request.Id);
            if(customer == null)
            {
                throw new Exception("კლიენტი ვერ მოიძებნა");
            }
            return ApiResponse<CustomerModel>.Success(customer.Map());
        }
    }
}
