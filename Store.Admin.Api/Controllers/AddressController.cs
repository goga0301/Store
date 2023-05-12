using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Admin.Handlers.Commands.Addresses;
using Store.Admin.Handlers.Queries.Addresses;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator, ILogger<AddressController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            return await _mediator.Send(new GetAddressQuery(Id));
        }

        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            return await _mediator.Send(new GetAddressesQuery());
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateAddressModel Address)
        {

            return await _mediator.Send(new CreateAddressCommand(Address));
        }

        [HttpPut("Update")]
        public async Task<IApiResponse> Update([FromBody] UpdateAddressModel Address)
        {
            return await _mediator.Send(new UpdateAddressCommand(Address));
        }

        [HttpDelete("Delete")]
        public async Task<IApiResponse> Delete([FromBody] DeleteAddressModel Address)
        {
            return await _mediator.Send(new DeleteAddressCommand(Address));
        }
    }
}