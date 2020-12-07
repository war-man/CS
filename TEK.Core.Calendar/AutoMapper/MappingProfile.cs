using AutoMapper;
using CS.EF.Models;
using CS.VM.Request;
using System;

namespace TEK.Core.Calendar.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddShiftRequest, Shift>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
               .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
               .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
               .ForMember(dest => dest.TimeId, opt => opt.MapFrom(src => src.TimeId));
        }
    }
}
