using Microsoft.AspNetCore.Mvc;
using Store.Domain.Models.Domain;
using Store.Domain.Service.Domain;
using Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            var result = await _transactionService.GetTransactionByIdAsync(Id);
            return ApiResponse<TransactionModel>.Success(result);
        }


        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            var result = await _transactionService.GetAllTransactions();
            return ApiResponse<IEnumerable<TransactionModel>>.Success(result);
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateTransactionModel transaction)
        {
            var Id = await _transactionService.AddTransaction(transaction);
            return ApiResponse<int>.Success(Id, "ტრანზაქცია დაემატა") ;
        }

        [HttpPut("Update")]
        public Task<IApiResponse> Update([FromBody] UpdateTransactionModel transaction)
        {
            _transactionService.UpdateTransaction(transaction);
            return Task.FromResult(ApiResponse.Success("ტრანზაქცია განახლდა"));
        }

        [HttpDelete("Delete")]
        public Task<IApiResponse> Delete(int Id)
        {
            _transactionService.DeleteTransaction(Id);
            return Task.FromResult(ApiResponse.Success("ტრანზაქცია წაიშალა"));
        }
    }
}