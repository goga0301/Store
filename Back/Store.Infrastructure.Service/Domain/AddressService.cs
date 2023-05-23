using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Domain.Service.Domain;

namespace Store.Infrastructure.Service.Domain
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<int> AddAddress(CreateAddressModel address)
        {
            return await _addressRepository.CreateAsync(address.Map());
        }

        public async void DeleteAddress(int Id)
        {
            var address = await _addressRepository.GetSingleAsync(x => x.Id == Id);
            if (address == null)
            {
                throw new Exception("მისამართი ვერ მოიძებნა");
            }

            _addressRepository.SoftDelete(address);
            await _addressRepository.SaveChangesAsync();
        }



        public async Task<AddressModel> GetAddressByIdAsync(int id)
        {
            var address = await _addressRepository.GetSingleAsync(x => x.Id == id);
            if (address == null)
            {
                throw new Exception("მისამართი ვერ მოიძებნა");
            }
            return address.Map();
        }

        public async void UpdateAddress(UpdateAddressModel addressUpdate)
        {
            var address = await _addressRepository.GetSingleAsync(x => x.Id == addressUpdate.Id);
            if (address == null)
            {
                throw new Exception("მისამართი ვერ მოიძებნა");
            }

            address.StreetAddress = addressUpdate.StreetAddress;
            address.City = addressUpdate.City;
            address.StateOrProvince = addressUpdate.StateOrProvince;
            address.PostalCode = addressUpdate.PostalCode;
            address.Country = addressUpdate.Country;
            address.Building = addressUpdate.Building;
            address.Floor = addressUpdate.Floor;

            _addressRepository.Update(address);
            await _addressRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<AddressModel>> GetAllAddresss()
        {
            return (await _addressRepository.GetAllAsync()).Select(x => x.Map());
        }
    }
}
