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

        [HttpGet, Route("all-rooms")]
        public async Task<IActionResult> GetRooms()
        {
            var response = await _shiftService.GetRooms();
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("add-new-room")]
        public async Task<IActionResult> AddNewRoom(string roomName)
        {
            var response = await _shiftService.AddNewRoom(roomName);
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("all-times")]
        public async Task<IActionResult> GetTimes()
        {
            var response = await _shiftService.GetTimes();
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("all-schedules")]
        public async Task<IActionResult> GetSChedules()
        {
            var response = await _shiftService.GetSchedules();
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("add-shift")]
        public async Task<IActionResult> AddShifts(AddShiftRequest shift)
        {
            var response = await _shiftService.AddShift(shift);
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("all-schedule-responses")]
        public async Task<IActionResult> GetAllScheduleResponses(string roomId)
        {
            var response = await _shiftService.GetAllScheduleResponses(roomId);
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("request-new-schedule")]
        public async Task<IActionResult> RequestNewSchedule(RequestNewScheduleController request)
        {
            string patientId;
            if (string.IsNullOrEmpty(request.PatientId))
            {
                patientId = await _shiftService.CreateNewPatient(request);
                request.PatientId = patientId;
            }

            var newScheduleRequest = new NewScheduleRequest
            {
                PatientId = request.PatientId,
                ShiftId = request.ShiftId,
                BHYT = request.BHYT
            };

            var response = await _shiftService.RequestNewSchedule(newScheduleRequest);

            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("change-schedule-status")]
        public async Task<IActionResult> ChangeScheduleStatus(ChangeScheduleStatusRequest request)
        {
            var response = await _shiftService.ChangeScheduleStatus(request);
            return Ok(new ApiOkResponse(response));
        }

        [HttpGet, Route("all-invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var response = await _shiftService.GetInvoices();
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("change-invoice-status")]
        public async Task<IActionResult> ChangeInvoiceStatus(ChangeInvoiceStatusRequest request)
        {
            var response = await _shiftService.ChangeInvoiceStatus(request);
            return Ok(new ApiOkResponse(response));
        }
    }
}
