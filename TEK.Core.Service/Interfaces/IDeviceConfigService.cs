using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace TEK.Core.Service.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TEK.Core.UoW.IService{CS.EF.Models.DeviceConfig, TEK.Core.UoW.IRepository{CS.EF.Models.DeviceConfig}}" />
    public interface IDeviceConfigService : IService<DeviceConfig, IRepository<DeviceConfig>>
    {
        /// <summary>
        /// Gets the device configuration.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        Task<List<DeviceConfigViewModel>> GetDeviceConfig(Guid deviceId);
        /// <summary>
        /// Gets the device configuration.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <returns></returns>
        Task<DeviceConfigViewModel> GetDeviceConfig(Guid deviceId, string packageName);
        /// <summary>
        /// Adds the configuration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<List<DeviceConfig>> AddConfig(AddDeviceConfigRequest request);

        /// <summary>
        /// Updates the configuration.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<DeviceConfigViewModel> UpdateConfig(UpdateDeviceCofigRequest request);
        /// <summary>
        /// Gets all configuration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<DeviceConfigResponse> GetAllConfig(DeviceConfigRequest request);
        /// <summary>
        /// Changes the active.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<List<DeviceConfig>> ChangeActive(ChangeActiveConfigRequest request);
        /// <summary>
        /// Scans the device configuration.
        /// </summary>
        /// <returns></returns>
        Task ScanDeviceConfig();

        /// <summary>
        /// Gets the logs.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="applicationId">The application identifier.</param>
        /// <returns></returns>
        Task<List<ApplicationLog>> GetLogs(Guid deviceId, Guid applicationId);
        /// <summary>
        /// Checks the device configuration.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="applicationId">The application identifier.</param>
        /// <returns></returns>
        Task<bool> CheckDeviceConfig(Guid deviceId, Guid applicationId);
        /// <summary>
        /// Uploads the logs.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="logsFile">The logs file.</param>
        /// <returns></returns>
        Task<UploadLogsResponse> UploadLogs(Guid deviceId, Guid applicationId, List<IFormFile> logsFile);

        Task<DeviceConfigViewModel> GetConfig(Guid deviceId, Guid applicationId);
    }
}
