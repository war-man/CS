using CS.VM.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TEK.Core.App.Middleware;
using TEK.Core.Service.Interfaces;

namespace TEK.Core.Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet, Route("get-all-patients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var response = await _cardService.GetAllPatients();
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("get-card-by-patientid")]
        public async Task<IActionResult> GetCardByPatientId(string patientId)
        {
            var response = await _cardService.GetCardByPatientId(patientId);
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> CreateNewCard(CreateCardRequest createCardRequest)
        {
            var response = await _cardService.CreateNewCard(createCardRequest);
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("top-up")]
        public async Task<IActionResult> TopUp(TopUpRequest topUpRequest)
        {
            var response = await _cardService.TopUp(topUpRequest);
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("return")]
        public async Task<IActionResult> ReturnCard(int cardNumber)
        {
            var response = await _cardService.ReturnCard(cardNumber);
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("change")]
        public async Task<IActionResult> ChangeCard(int cardNumber)
        {
            var response = await _cardService.ChangeCard(cardNumber);
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("block")]
        public async Task<IActionResult> BlockCard(int cardNumber)
        {
            var response = await _cardService.BlockCard(cardNumber);
            return Ok(new ApiOkResponse(response));
        }
    }
}
