using Microsoft.AspNetCore.Mvc;
using Store.Domain.Models.Domain;
using Store.Domain.Service.Domain;
using Shared.Helpers;

namespace Store.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ICardService _cardService;

        public CardController(ICardService cardService, ILogger<CardController> logger)
        {
            _cardService = cardService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IApiResponse> Get(int Id)
        {
            var result = await _cardService.GetCardByIdAsync(Id);
            return ApiResponse<CardModel>.Success(result);
        }


        [HttpGet("GetAll")]
        public async Task<IApiResponse> GetAll()
        {
            var result = await _cardService.GetAllCards();
            return ApiResponse<IEnumerable<CardModel>>.Success(result);
        }

        [HttpPost("Create")]
        public async Task<IApiResponse> Create([FromBody] CreateCardModel card)
        {
            var Id = await _cardService.AddCard(card);
            return ApiResponse<int>.Success(Id,"ბარათი დაემატა");
        }

        [HttpPut("Update")]
        public Task<IApiResponse> Update([FromBody] UpdateCardModel card)
        {
            _cardService.UpdateCard(card);
            return Task.FromResult(ApiResponse.Success("ბარათი განახლდა"));
        }

        [HttpDelete("Delete")]
        public Task<IApiResponse> Delete(int Id)
        {
            _cardService.DeleteCard(Id);
            return Task.FromResult(ApiResponse.Success("ბარათი წაიშალა"));
        }
    }
}