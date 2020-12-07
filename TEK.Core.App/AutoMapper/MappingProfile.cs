using AutoMapper;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using System;
using static CS.Common.Common.Constants;

namespace TEK.Core.App.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddOrUpdateDeviceRequest, Device>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => Systems.CreatedBy))
               .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => Systems.CreatedBy));

            CreateMap<AddOrUpdateVersionRequest, CS.EF.Models.Version>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => Systems.CreatedBy))
               .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => Systems.CreatedBy));

            CreateMap<CS.EF.Models.Version, VersionViewModel>()
                .ForMember(dest => dest.Bundles, opt => opt.Ignore());

            CreateMap<Device, DeviceViewModel>();

            CreateMap<Application, ApplicationViewModel>()
                 //.ForMember(dest => dest.Device, opt => opt.Ignore())
                 .ForMember(dest => dest.Versions, opt => opt.Ignore());

            CreateMap<Bundle, BundleViewModel>();

            CreateMap<AddOrUpdateVersionRequest, Bundle>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
               .ForMember(dest => dest.ReleaseNote, opt => opt.MapFrom(src => src.BundleInfomation.ReleaseNote))
               .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => Systems.CreatedBy))
               .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => Systems.CreatedBy));

            CreateMap<AddOrUpdateApplicationRequest, Application>();
            CreateMap<AddCommandRequest, Command>();
            CreateMap<DeviceConfig, DeviceConfigViewModel>();
            CreateMap<Command, CommandViewModel>();
            CreateMap<DeviceConfig, DeviceConfigViewModel>();

            CreateMap<ImportDeviceModel, ImportDeviceData>()
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.Type, opt => opt.Ignore());

            CreateMap<ImportDeviceData, Device>();
        }
    }
}
