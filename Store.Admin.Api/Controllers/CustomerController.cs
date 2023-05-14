using Microsoft.AspNetCore.Mvc;
using Store.Domain.Models.Domain;
using Store.Domain.Service.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            var result = await _customerService.GetCustomerByIdAsync(Id);
            return ApiResponse<CustomerModel>.Success(result);
        }


        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            var result = await _customerService.GetAllCustomers();
            return ApiResponse<IEnumerable<CustomerModel>>.Success(result);
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateCustomerModel customer)
        {
            var Id = await _customerService.AddCustomer(customer);
            return ApiResponse<int>.Success(Id, "მომხმარებელი დაემატა");
        }

        [HttpPut("Update")]
        public Task<IApiResponse> Update([FromBody] UpdateCustomerModel customer)
        {
            _customerService.UpdateCustomer(customer);
            return Task.FromResult(ApiResponse.Success("მომხმარებელი განახლდა"));
        }

        [HttpDelete("Delete")]
        public Task<IApiResponse> Delete(int Id)
        {
            _customerService.DeleteCustomer(Id);
            return Task.FromResult(ApiResponse.Success("მომხმარებელი წაიშალა"));
        }
    }
}