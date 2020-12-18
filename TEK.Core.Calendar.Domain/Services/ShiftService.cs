using AutoMapper;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Request;
using CS.VM.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var result =  await _unitOfWork.GetRepository<Shift>().GetAll().OrderBy(x => x.Date).ToListAsync();

            return new ShiftResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<DoctorResponse> GetDoctors()
        {
            var result = await _unitOfWork.GetRepository<Doctor>().GetAll().OrderBy(x => x.Id).ToListAsync();

            return new DoctorResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<Doctor> AddNewDoctor(AddNewDoctorRequest request)
        {
            var doctor = _mapper.Map<Doctor>(request);
            doctor.Id = newDoctorID();
            _unitOfWork.GetRepository<Doctor>().Add(doctor);
            await _unitOfWork.CommitAsync();
            return doctor;
        }

        public async Task<RoomResponse> GetRooms()
        {
            var result = await _unitOfWork.GetRepository<Room>().GetAll().OrderBy(x => x.Id).ToListAsync();

            return new RoomResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<Room> AddNewRoom(string roomName)
        {
            var s = await _unitOfWork.GetRepository<Room>().FindAsync(x => x.Name == roomName);

            if (s != null)
                throw new Exception("Trùng tên");

            var room = new Room
            {
                Id = newRoomID(),
                Name = roomName
            };

            _unitOfWork.GetRepository<Room>().Add(room);
            await _unitOfWork.CommitAsync();
            return room;
        }

        public async Task<TimeResponse> GetTimes()
        {
            var result = await _unitOfWork.GetRepository<Time>().GetAll().OrderBy(x => x.Id).ToListAsync();

            return new TimeResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<ScheduleResponse> GetSchedules()
        {
            var result = await _unitOfWork.GetRepository<Schedule>().GetAll().OrderBy(x => x.Id).ToListAsync();

            return new ScheduleResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<Shift> AddShift(AddShiftRequest request)
        {
            var s = await _unitOfWork.GetRepository<Shift>().FindAsync(x => x.RoomId == request.RoomId && x.DoctorId == request.DoctorId && x.Date.Date == request.Date.Date && x.TimeId == request.TimeId);

            if (s != null)
                throw new Exception("Trùng lịch");

            var shift = _mapper.Map<Shift>(request);
            shift.Id = newShiftID();
            _unitOfWork.GetRepository<Shift>().Add(shift);
            await _unitOfWork.CommitAsync();
            return shift;
        }

        public async Task<string> CreateNewPatient(CreateNewPatientRequest request)
        {
            var id = newPatientID();
            Patient patient = new Patient
            {
                Id = id,
                Name = request.Name,
                Birthday = request.Birthday,
                Gender = request.Gender,
                Phone = request.Phone,
                Address = request.Address
            };

             _unitOfWork.GetRepository<Patient>().Add(patient);
            await _unitOfWork.CommitAsync();
            return id;
        }

        public async Task<NewScheduleResponse> RequestNewSchedule(NewScheduleRequest request)
        {
            var s = await _unitOfWork.GetRepository<Schedule>().FindAsync(x => x.PatientId == request.PatientId && x.ShiftId == request.ShiftId);

            if (s != null)
                throw new Exception("Bệnh nhân đã đăng ký ca này");

            var ordr = 1;
            var s1 = await _unitOfWork.GetRepository<Schedule>().FindAsync(x => x.ShiftId == request.ShiftId && x.PatientId != request.PatientId);

            if (s1 != null)
                ordr = s1.Order + 1;

            var id = newScheduleID();
            Schedule schedule = new Schedule
            {
                Id = id,
                ShiftId = request.ShiftId,
                PatientId = request.PatientId,
                Status = 1,
                Order = ordr,
                BHYT = request.BHYT
            };

            _unitOfWork.GetRepository<Schedule>().Add(schedule);
            await _unitOfWork.CommitAsync();

            var p = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Id == request.PatientId);

            var shift = await _unitOfWork.GetRepository<Shift>().FindAsync(x => x.Id == request.ShiftId);

            var room = await _unitOfWork.GetRepository<Room>().FindAsync(x => x.Id == shift.RoomId);

            var doctor = await _unitOfWork.GetRepository<Doctor>().FindAsync(x => x.Id == shift.DoctorId);

            var time = await _unitOfWork.GetRepository<Time>().FindAsync(x => x.Id == shift.TimeId);

            return new NewScheduleResponse
            {
                Id = id,
                PatientId = p.Id,
                Name = p.Name,
                Birthday = p.Birthday,
                Room = room.Name,
                Doctor = doctor.Name,
                Date = shift.Date,
                Time = time.ShiftTime,
                Order = ordr,
                Status = 1,
                BHYT = request.BHYT
            };
        }

        public async Task<List<NewScheduleResponse>> GetAllScheduleResponses(string roomId)
        {
            var shifts = !string.IsNullOrEmpty(roomId) ? await _unitOfWork.GetRepository<Shift>().GetAll().Where(x => x.RoomId == roomId).ToListAsync()
                : await _unitOfWork.GetRepository<Shift>().GetAll().ToListAsync();

            var lstNsr = new List<NewScheduleResponse>();

            var lstNsrC = new List<NewScheduleResponse>();

            foreach (var shift in shifts)
            {
                var schedules = await _unitOfWork.GetRepository<Schedule>().GetAll().Where(x => x.ShiftId == shift.Id).ToListAsync();

                if (schedules != null)
                {
                    foreach (var schedule in schedules)
                    {
                        var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Id == schedule.PatientId);

                        var room = await _unitOfWork.GetRepository<Room>().FindAsync(x => x.Id == shift.RoomId);

                        var doctor = await _unitOfWork.GetRepository<Doctor>().FindAsync(x => x.Id == shift.DoctorId);

                        var time = await _unitOfWork.GetRepository<Time>().FindAsync(x => x.Id == shift.TimeId);

                        var ncr = new NewScheduleResponse
                        {
                            Id = schedule.Id,
                            PatientId = schedule.PatientId,
                            Name = patient.Name,
                            Birthday = patient.Birthday,
                            Room = room.Name,
                            Doctor = doctor.Name,
                            Date = shift.Date,
                            Time = time.ShiftTime,
                            Order = schedule.Order,
                            Status = schedule.Status,
                            BHYT = schedule.BHYT
                        };

                        if (schedule.Status != 5)
                        {
                            lstNsr.Add(ncr);
                        }
                        else
                        {
                            lstNsrC.Add(ncr);
                        }
                    }
                }
            }

            if (lstNsrC.Count > 0)
            {
                foreach (var ncr in lstNsrC)
                {
                    lstNsr.Add(ncr);
                }
            }

            return lstNsr;
        }

        public async Task<Schedule> ChangeScheduleStatus(ChangeScheduleStatusRequest request)
        {
            var schedule = await _unitOfWork.GetRepository<Schedule>().FindAsync(x => x.Id == request.Id);

            schedule.Status = request.Status;

            _unitOfWork.GetRepository<Schedule>().Update(schedule);

            if (request.Status == 5)
            {
                var shift = await _unitOfWork.GetRepository<Shift>().GetAll().FirstOrDefaultAsync(x => x.Id == schedule.ShiftId);
                var service = await _unitOfWork.GetRepository<CS.EF.Models.Services>().FindAsync(x => x.RoomId == shift.RoomId);

                var invoice = new Invoice
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    PatientId = schedule.PatientId,
                    ScheduleId = schedule.Id,
                    Content = "Khám bệnh" + service.Name.Remove(0, 2).ToLower(),
                    Cost = service.Cost,
                    CreateBy = "SYSTEM",
                    Status = 1
                };

                _unitOfWork.GetRepository<Invoice>().Add(invoice);
            }

            await _unitOfWork.CommitAsync();

            return schedule;
        }

        public async Task<List<Invoice>> GetInvoices()
        {
            var schedule = await _unitOfWork.GetRepository<Invoice>().GetAll().ToListAsync();

            return schedule;
        }

        public async Task<Invoice> ChangeInvoiceStatus(ChangeInvoiceStatusRequest request)
        {
            var invoice = await _unitOfWork.GetRepository<Invoice>().FindAsync(x => x.Id == request.Id);

            invoice.Status = request.Status;

            if (request.Status == 2)
            {
                var card = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.PatientId == invoice.PatientId && x.Status == 1);

                if (card != null)
                {
                    card.Money = card.Money - invoice.Cost;

                    _unitOfWork.GetRepository<Card>().Update(card);
                }
            }

            _unitOfWork.GetRepository<Invoice>().Update(invoice);
            await _unitOfWork.CommitAsync();
            return invoice;
        }

        private string newPatientID()
        {
            int cc = _unitOfWork.GetRepository<Patient>().GetAll().Count();
            if (cc < 9)
            {
                return "P00" + (cc + 1);
            }
            return "P0" + (cc + 1);
        }

        private string newScheduleID()
        {
            int cc = _unitOfWork.GetRepository<Schedule>().GetAll().Count();
            if (cc < 9)
            {
                return "SC00" + (cc + 1);
            }
            return "SC0" + (cc + 1);
        }

        private string newShiftID()
        {
            int cc = _unitOfWork.GetRepository<Shift>().GetAll().Count();
            if (cc < 9)
            {
                return "S00" + (cc + 1);
            }
            return "S0" + (cc + 1);
        }

        private string newDoctorID()
        {
            int cc = _unitOfWork.GetRepository<Doctor>().GetAll().Count();
            if (cc < 9)
            {
                return "D00" + (cc + 1);
            }
            return "D0" + (cc + 1);
        }

        private string newRoomID()
        {
            int cc = _unitOfWork.GetRepository<Room>().GetAll().Count();
            if (cc < 9)
            {
                return "R00" + (cc + 1);
            }
            return "R0" + (cc + 1);
        }
    }
}
