using MediatR;
using Store.Admin.Handlers.Commands.Customers;
using Store.Domain.Repository;
using Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.Customers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, IApiResponse<bool>>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IApiResponse<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var customer = await _customerRepository.GetAsync(x => x.Id == request.Model.Id);
                if (customer == null)
                {
                    throw new Exception("კლიენტი ვერ მოიძებნა");
                }
                customer.FirstName = request.Model.FirstName;
                customer.LastName = request.Model.LastName;
                customer.PhoneNumber = request.Model.PhoneNumber;
                customer.Email = request.Model.Email;
                customer.UserName = request.Model.UserName;
                customer.Password = request.Model.Password;
                customer.Gender = request.Model.Gender;
                customer.BirthDate = request.Model.BirthDate;

                _customerRepository.Update(customer);
                await _customerRepository.SaveChangesAsync();
                scope.Complete();
                return ApiResponse<bool>.Success(true, "კლიენტი განახლდა");
            }
        }
    }
}
