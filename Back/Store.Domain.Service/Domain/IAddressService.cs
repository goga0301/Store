using Store.Domain.Models.Domain;

namespace Store.Domain.Service.Domain
{
    public interface IAddressService
    {
        Task<int> AddAddress(CreateAddressModel address);
        void UpdateAddress(UpdateAddressModel address);
        void DeleteAddress(int Id);
        Task<AddressModel> GetAddressByIdAsync(int Id);
        Task<IEnumerable<AddressModel>> GetAllAddresss();
    }
}
