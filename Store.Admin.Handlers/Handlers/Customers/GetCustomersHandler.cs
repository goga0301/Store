using MediatR;
using Store.Admin.Handlers.Queries.Customers;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Admin.Handlers.Handlers.Customers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IApiResponse<IEnumerable<CustomerModel>>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomersHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IApiResponse<IEnumerable<CustomerModel>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            return ApiResponse<IEnumerable<CustomerModel>>.Success(customers.Select(x => x.Map()));
        }
    }
}
