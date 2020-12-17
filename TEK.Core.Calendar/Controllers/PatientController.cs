using CS.VM.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.App.Middleware;
using TEK.Core.Service.Interfaces;

namespace TEK.Core.Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ICardService _cardService;

        public PatientController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet, Route("get-all-patients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var response = await _cardService.GetAllPatients();
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("add-new-patient")]
        public async Task<IActionResult> AddNewPatient(AddNewPatientRequest request)
        {
            var response = await _cardService.AddNewPatient(request);
            return Ok(new ApiOkResponse(response));
        }
    }
}
