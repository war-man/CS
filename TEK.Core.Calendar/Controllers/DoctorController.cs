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
    public class DoctorController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public DoctorController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet, Route("all-doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            var response = await _shiftService.GetDoctors();
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("add-new-doctor")]
        public async Task<IActionResult> AddNewPatient(AddNewDoctorRequest request)
        {
            var response = await _shiftService.AddNewDoctor(request);
            return Ok(new ApiOkResponse(response));
        }
    }
}
