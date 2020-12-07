using AutoMapper;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Request;
using CS.VM.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Core.Calendar.Domain.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShiftService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ShiftResponse> GetShifts()
        {
            var result =  await _unitOfWork.GetRepository<Shift>().GetAll().ToListAsync();

            return new ShiftResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<DoctorResponse> GetDoctors()
        {
            var result = await _unitOfWork.GetRepository<Doctor>().GetAll().ToListAsync();

            return new DoctorResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<RoomResponse> GetRooms()
        {
            var result = await _unitOfWork.GetRepository<Room>().GetAll().ToListAsync();

            return new RoomResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<TimeResponse> GetTimes()
        {
            var result = await _unitOfWork.GetRepository<Time>().GetAll().ToListAsync();

            return new TimeResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<Shift> Add(AddShiftRequest request)
        {
            var s = await _unitOfWork.GetRepository<Shift>().FindAsync(x => x.RoomId == request.RoomId && x.DoctorId == request.DoctorId && x.Date.Date == request.Date.Date && x.TimeId == request.TimeId);

            if (s != null)
                throw new Exception("Trùng lịch");

            var shift = _mapper.Map<Shift>(request);
            _unitOfWork.GetRepository<Shift>().Add(shift);
            await _unitOfWork.CommitAsync();
            return shift;
        }
    }
}
