// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IDeviceService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace TEK.Core.Service.Interfaces
{
    /// <summary>
    /// Interface IDeviceService
    /// Implements the <see cref="CS.Base.IService{Device, CS.Base.IRepository{Device}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{Device, CS.Base.IRepository{Device}}" />
    public interface IDeviceService : IService<Device, IRepository<Device>>
    {
        /// <summary>
        /// Adds the or update device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<DeviceViewModel> AddOrUpdateDevice(AddOrUpdateDeviceRequest request);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetDeviceResponse> GetAll(GetDeviceRequest request);
        /// <summary>
        /// Verifies the device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ImportDeviceResponse> VerifyDevice(List<ImportDeviceModel> request);
        /// <summary>
        /// Processes the import.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> ProcessImport(ProcessImportDeviceRequest request);
        /// <summary>
        /// Scans the device.
        /// </summary>
        /// <returns></returns>
        Task ScanDevice();
    }
}
