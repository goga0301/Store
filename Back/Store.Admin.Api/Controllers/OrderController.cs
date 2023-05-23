using Microsoft.AspNetCore.Mvc;
using Store.Domain.Models.Domain;
using Store.Domain.Service.Domain;
using Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            var result = await _orderService.GetOrderByIdAsync(Id);
            return ApiResponse<OrderModel>.Success(result);
        }


        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            var result = await _orderService.GetAllOrders();
            return ApiResponse<IEnumerable<OrderModel>>.Success(result);
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateOrderModel order)
        {
            var Id  = await _orderService.AddOrder(order);
            return ApiResponse<int>.Success(Id, "შეკვეთა დაემატა");
        }

        [HttpPut("Update")]
        public Task<IApiResponse> Update([FromBody] UpdateOrderModel order)
        {
            _orderService.UpdateOrder(order);
            return Task.FromResult(ApiResponse.Success("შეკვეთა განახლდა"));
        }

        [HttpDelete("Delete")]
        public Task<IApiResponse> Delete(int Id)
        {
            _orderService.DeleteOrder(Id);
            return Task.FromResult(ApiResponse.Success("შეკვეთა წაიშალა"));
        }
    }
}