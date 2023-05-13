using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Domain.Service.Domain;

namespace Store.Infrastructure.Service.Domain
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async void AddCustomer(CreateCustomerModel customer)
        {
            _customerRepository.Create(customer.Map());
            await _customerRepository.SaveChangesAsync();
        }

        public async void DeleteCustomer(int Id)
        {
            var customer = await _customerRepository.GetSingleAsync(x => x.Id == Id);
            if (customer == null)
            {
                throw new Exception("მომხმარებელი ვერ მოიძებნა");
            }

            _customerRepository.SoftDelete(customer);
            await _customerRepository.SaveChangesAsync();
        }



        public async Task<CustomerModel> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetSingleAsync(x => x.Id == id, i => i.Addresses, i => i.Cards, i => i.Orders );
            if (customer == null)
            {
                throw new Exception("მომხმარებელი ვერ მოიძებნა");
            }
            return customer.Map();
        }

        public async void UpdateCustomer(UpdateCustomerModel customerUpdate)
        {
            var customer = await _customerRepository.GetSingleAsync(x => x.Id == customerUpdate.Id);
            if (customer == null)
            {
                throw new Exception("მომხმარებელი ვერ მოიძებნა");
            }

            customer.FirstName = customerUpdate.FirstName;
            customer.LastName = customerUpdate.LastName;
            customer.PhoneNumber = customerUpdate.PhoneNumber;
            customer.Email = customerUpdate.Email;
            customer.UserName = customerUpdate.UserName;
            customer.Password = customerUpdate.Password;
            customer.Gender = customerUpdate.Gender;
            customer.BirthDate = customerUpdate.BirthDate;

            _customerRepository.Update(customer);
            await _customerRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            return (await _customerRepository.GetAllAsync(i => i.Addresses, i => i.Cards, i => i.Orders)).Select(x => x.Map());
        }
    }
}
