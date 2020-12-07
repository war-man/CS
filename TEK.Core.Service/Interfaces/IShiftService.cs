using CS.EF.Models;
using CS.VM.Request;
using CS.VM.Response;
using System.Threading.Tasks;

namespace TEK.Core.Service.Interfaces
{
    public interface IShiftService
    {
        Task<ShiftResponse> GetShifts();
        Task<DoctorResponse> GetDoctors();
        Task<RoomResponse> GetRooms();
        Task<TimeResponse> GetTimes();
        Task<ScheduleResponse> GetSchedules();
        Task<Shift> AddShift(AddShiftRequest request);
    }
}
