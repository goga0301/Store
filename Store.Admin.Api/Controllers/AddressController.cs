using Microsoft.AspNetCore.Mvc;
using Store.Domain.Models.Domain;
using Store.Domain.Service.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService, ILogger<AddressController> logger)
        {
            _addressService = addressService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            var result = await _addressService.GetAddressByIdAsync(Id);
            return ApiResponse<AddressModel>.Success(result);
        }


        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            var result = await _addressService.GetAllAddresss();
            return ApiResponse<IEnumerable<AddressModel>>.Success(result);
        }

        [HttpPost("Create")]
        public Task<IApiResponse> Create([FromBody] CreateAddressModel address)
        {
            _addressService.AddAddress(address);
            return Task.FromResult(ApiResponse.Success("მისამართი დაემატა"));
        }

        [HttpPut("Update")]
        public Task<IApiResponse> Update([FromBody] UpdateAddressModel address)
        {
            _addressService.UpdateAddress(address);
            return Task.FromResult(ApiResponse.Success("მისამართი განახლდა"));
        }

        [HttpDelete("Delete")]
        public Task<IApiResponse> Delete(int Id)
        {
            _addressService.DeleteAddress(Id);
            return Task.FromResult(ApiResponse.Success("მისამართი წაიშალა"));
        }
    }
}