using Store.Domain.Models.Domain;

namespace Store.Domain.Service.Domain
{
    public interface ICustomerService
    {
        void AddCustomer(CreateCustomerModel customer);
        void UpdateCustomer(UpdateCustomerModel customer);
        void DeleteCustomer(int Id);
        Task<CustomerModel> GetCustomerByIdAsync(int Id);
        Task<IEnumerable<CustomerModel>> GetAllCustomers();
    }
}
