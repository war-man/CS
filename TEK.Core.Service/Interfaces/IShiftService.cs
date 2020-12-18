using CS.EF.Models;
using CS.VM.Request;
using CS.VM.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TEK.Core.Service.Interfaces
{
    public interface IShiftService
    {
        Task<ShiftResponse> GetShifts();
        Task<DoctorResponse> GetDoctors();
        Task<Doctor> AddNewDoctor(AddNewDoctorRequest request);
        Task<RoomResponse> GetRooms();
        Task<Room> AddNewRoom(string roomName);
        Task<TimeResponse> GetTimes();
        Task<ScheduleResponse> GetSchedules();
        Task<Shift> AddShift(AddShiftRequest request);
        Task<string> CreateNewPatient(CreateNewPatientRequest request);
        Task<NewScheduleResponse> RequestNewSchedule(NewScheduleRequest request);
        Task<List<NewScheduleResponse>> GetAllScheduleResponses(string roomId);
        Task<Schedule> ChangeScheduleStatus(ChangeScheduleStatusRequest request);
        Task<List<Invoice>> GetInvoices();
        Task<Invoice> ChangeInvoiceStatus(ChangeInvoiceStatusRequest request);
    }
}
