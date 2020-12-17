using CS.VM.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TEK.Core.App.Middleware;
using TEK.Core.Service.Interfaces;

namespace TEK.Core.Calendar.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet, Route("all")]
        public async Task<IActionResult> GetAllCards()
        {
            var response = await _cardService.GetAllCards();
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("get-all-auditlogs")]
        public async Task<IActionResult> GetAllAuditLogs()
        {
            var response = await _cardService.GetAllAuditLogs();
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("get-revenue-statistics")]
        public async Task<IActionResult> GetRevenueStatistics()
        {
            var response = await _cardService.GetRevenueStatistics();
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("get-revenue-statistic-by-action")]
        public async Task<IActionResult> GetRevenueStatisticsByAction(string action)
        {
            var response = await _cardService.GetRevenueStatisticsByAction(action);
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("get-revenue-statistic-by-date")]
        public async Task<IActionResult> GetRevenueStatisticsByDate(DateTime date)
        {
            var response = await _cardService.GetRevenueStatisticsByDate(date);
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("get-revenue-statistic-by-action-and-date")]
        public async Task<IActionResult> GetRevenueStatisticsByActionAndDate(string action, DateTime date)
        {
            var response = await _cardService.GetRevenueStatisticsByActionAndDate(action, date);
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("get-card-by-patientid")]
        public async Task<IActionResult> GetCardByPatientId(string patientId)
        {
            var response = await _cardService.GetCardByPatientId(patientId);
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("get-full-info")]
        public async Task<IActionResult> GetFullPatientCard(PatientCardRequest patientCardRequest)
        {
            var response = await _cardService.GetFullPatientCard(patientCardRequest);
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

        [HttpPost, Route("change-card-status")]
        public async Task<IActionResult> ChangeCardStatus(ChangeCardStatusRequest changeCardStatusRequest)
        {
            int cardNumber = changeCardStatusRequest.CardNumber;
            if (changeCardStatusRequest.Status == 2)
            {
                var response = await _cardService.ChangeCard(cardNumber);
                return Ok(new ApiOkResponse(response));
            }
            else if (changeCardStatusRequest.Status == 3)
            {
                var response = await _cardService.ReturnCard(cardNumber);
                return Ok(new ApiOkResponse(response));
            }
            else if (changeCardStatusRequest.Status == 4)
            {
                var response = await _cardService.BlockCard(cardNumber);
                return Ok(new ApiOkResponse(response));
            }

            return NotFound();
        }
    }
}