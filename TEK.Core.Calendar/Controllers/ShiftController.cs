using CS.EF.Models;
using CS.VM.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TEK.Core.App.Middleware;
using TEK.Core.Service.Interfaces;

namespace TEK.Core.Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet, Route("all-shifts")]
        public async Task<IActionResult> GetShifts()
        {
            var response = await _shiftService.GetShifts();
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("all-doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            var response = await _shiftService.GetDoctors();
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("all-rooms")]
        public async Task<IActionResult> GetRooms()
        {
            var response = await _shiftService.GetRooms();
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("all-times")]
        public async Task<IActionResult> GetTimes()
        {
            var response = await _shiftService.GetTimes();
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> AddShifts(AddShiftRequest shift)
        {
            var response = await _shiftService.Add(shift);
            return Ok(new ApiOkResponse(response));
        }
    }
}
