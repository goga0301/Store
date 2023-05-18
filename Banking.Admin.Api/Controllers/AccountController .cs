using Banking.Domain.Models.Models;
using Banking.Domain.Service.Domain;
using Microsoft.AspNetCore.Mvc;
using Shared.Helpers;

namespace Banking.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            var result = await _accountService.GetAccountByIdAsync(Id);
            return ApiResponse<AccountModel>.Success(result);
        }


        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            var result = await _accountService.GetAllAccounts();
            return ApiResponse<IEnumerable<AccountModel>>.Success(result);
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateAccountModel account)
        {
            var Id = await _accountService.AddAccount(account);
            return ApiResponse<int>.Success(Id, "ანგარიში დაემატა");
        }

        [HttpPut("Update")]
        public Task<IApiResponse> Update([FromBody] UpdateAccountModel account)
        {
            _accountService.UpdateAccount(account);
            return Task.FromResult(ApiResponse.Success("ანგარიში განახლდა"));
        }

        [HttpDelete("Delete")]
        public Task<IApiResponse> Delete(int Id)
        {
            _accountService.DeleteAccount(Id);
            return Task.FromResult(ApiResponse.Success("ანგარიში წაიშალა"));
        }
    }
}