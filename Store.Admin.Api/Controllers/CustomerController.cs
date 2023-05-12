using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Admin.Handlers.Commands.Customers;
using Store.Admin.Handlers.Queries.Customers;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            return await _mediator.Send(new GetCustomerQuery(Id));
        }

        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            return await _mediator.Send(new GetCustomersQuery());
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateCustomerModel Customer)
        {

            return await _mediator.Send(new CreateCustomerCommand(Customer));
        }

        [HttpPut("Update")]
        public async Task<IApiResponse> Update([FromBody] UpdateCustomerModel Customer)
        {
            return await _mediator.Send(new UpdateCustomerCommand(Customer));
        }

        [HttpDelete("Delete")]
        public async Task<IApiResponse> Delete([FromBody] DeleteCustomerModel Customer)
        {
            return await _mediator.Send(new DeleteCustomerCommand(Customer));
        }
    }
}