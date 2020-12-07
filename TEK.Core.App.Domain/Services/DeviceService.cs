// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="DeviceService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AutoMapper;
using CS.Common.Common;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using TEK.Email.Interfaces;
using static CS.Common.Common.Constants;
using CS.EF.Models;

namespace TEK.Core.App.Domain.Services
{
    /// <summary>
    /// Class DeviceService.
    /// Implements the <see cref="CS.Abstractions.IServices.IDeviceService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.IDeviceService" />
    public class DeviceService : IDeviceService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Settings _settings;
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public DeviceService(IUnitOfWork unitOfWork, IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IEmailSender emailSender,
            Settings settings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _settings = settings;
            _emailSender = emailSender;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Device.</returns>
        public Device Add(Device entity)
        {
            _unitOfWork.GetRepository<Device>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Device.</returns>
        public async Task<Device> AddAsync(Device entity)
        {
            _unitOfWork.GetRepository<Device>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Device>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Device>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Device entity)
        {
            _unitOfWork.GetRepository<Device>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Device>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Device entity)
        {
            _unitOfWork.GetRepository<Device>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Device>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Device.</returns>
        public Device Find(Expression<Func<Device, bool>> match)
        {
            return _unitOfWork.GetRepository<Device>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public ICollection<Device> FindAll(Expression<Func<Device, bool>> match)
        {
            return _unitOfWork.GetRepository<Device>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public async Task<ICollection<Device>> FindAllAsync(Expression<Func<Device, bool>> match)
        {
            return await _unitOfWork.GetRepository<Device>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Device.</returns>
        public async Task<Device> FindAsync(Expression<Func<Device, bool>> match)
        {
            return await _unitOfWork.GetRepository<Device>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public Device Get(Guid id)
        {
            return _unitOfWork.GetRepository<Device>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public ICollection<Device> GetAll()
        {
            return _unitOfWork.GetRepository<Device>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public async Task<ICollection<Device>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Device>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public async Task<Device> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Device>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public Device Update(Device entity, Guid id)
        {
            if (entity == null)
                return null;

            Device existing = _unitOfWork.GetRepository<Device>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Device>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public async Task<Device> UpdateAsync(Device entity, Guid id)
        {
            if (entity == null)
                return null;

            Device existing = await _unitOfWork.GetRepository<Device>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Device>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion

        /// <summary>
        /// Adds the or update device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<DeviceViewModel> AddOrUpdateDevice(AddOrUpdateDeviceRequest request)
        {
            var device = await _unitOfWork.GetRepository<Device>().FindAsync(x => x.Id == request.Id);

            var applications = await _unitOfWork.GetRepository<Application>().GetAll().Where(x => request.ApplicationIds.Contains(x.Id)).ToListAsync();
            if (device == null)
            {
                var newDevice = _mapper.Map<Device>(request);

                foreach (var item in applications)
                {
                    newDevice.Applications.Add(item);
                }

                _unitOfWork.GetRepository<Device>().Add(newDevice);
                device = newDevice;
            }
            else
            {
                var deviceConfigs = _unitOfWork.GetRepository<DeviceConfig>().GetAll().Where(x => x.DeviceId == device.Id);

                foreach (var item in deviceConfigs)
                {
                    item.DeviceName = request.Name;
                    item.AreaCode = request.AreaCode;
                    _unitOfWork.GetRepository<DeviceConfig>().Update(item);
                }

                if (device.Applications.Count > 0)
                {
                    foreach (var item in device.Applications.ToList())
                    {
                        device.Applications.Remove(item);
                    }
                }

                foreach (var item in applications)
                {
                    device.Applications.Add(item);
                }
                device.Ip = request.Ip;
                device.Type = request.Type;
                device.AreaCode = request.AreaCode;
                device.IsActive = request.IsActive;
                device.Code = request.Code;
                device.Name = request.Name;
                device.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<Device>().Update(device);
            }
            await _unitOfWork.CommitAsync();
            return _mapper.Map<DeviceViewModel>(device);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetDeviceResponse> GetAll(GetDeviceRequest request)
        {
            var devices = _unitOfWork.GetRepository<Device>().GetAll();

            if (!string.IsNullOrEmpty(request.AreaCode))
                devices = devices.Where(x => x.AreaCode == request.AreaCode);

            if (!string.IsNullOrEmpty(request.DeviceName))
                devices = devices.Where(x => x.Name.ToLower().Contains(request.DeviceName.ToLower()));

            if (request.Type.HasValue)
                devices = devices.Where(x => x.Type == request.Type.Value);

            if (request.IsActive.HasValue)
                devices = devices.Where(x => x.IsActive == request.IsActive.Value);

            var total = await devices.CountAsync();
            var devicesView = new List<DeviceViewModel>();
            var result = await devices.Skip(request.Skip).Take(request.Take).OrderByDescending(x => x.UpdatedDate).ToListAsync();

            foreach (var item in result)
            {
                var response = _mapper.Map<DeviceViewModel>(item);
                response.Applications = new List<ApplicationViewModel>();
                devicesView.Add(response);
            }

            return new GetDeviceResponse
            {
                Data = devicesView,
                Total = total
            };
        }

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Command> AddCommand(AddCommandRequest request)
        {
            var device = await _unitOfWork.GetRepository<Device>().FindAsync(x => x.Id == request.DeviceId);

            var application = await _unitOfWork.GetRepository<Application>().FindAsync(x => x.Id == request.ApplicationId);

            if (device == null || application == null)
                throw new Exception(ErrorMessages.NotFounDeviceOrApp);

            var command = _mapper.Map<Command>(request);

            _unitOfWork.GetRepository<Command>().Add(command);
            await _unitOfWork.CommitAsync();
            return command;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        public async Task<List<CommandViewModel>> GetCommand(Guid deviceId)
        {
            var deviceCommands = await _unitOfWork.GetRepository<Command>().GetAll().Where(x => x.DeviceId == deviceId).AsNoTracking().ToListAsync();
            return _mapper.Map<List<CommandViewModel>>(deviceCommands);
        }

        public async Task<List<CommandViewModel>> GetCommand(Guid deviceId, string packageName)
        {
            var deviceCommands = await _unitOfWork.GetRepository<Command>().GetAll().Where(x => x.DeviceId == deviceId && x.PackageName == packageName).AsNoTracking().ToListAsync();
            return _mapper.Map<List<CommandViewModel>>(deviceCommands);
        }

        /// <summary>
        /// Deletes the command.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="applicationId">The application identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteCommand(Guid deviceId, Guid applicationId)
        {
            var command = await _unitOfWork.GetRepository<Command>().FindAsync(x => x.DeviceId == deviceId && x.ApplicationId == applicationId);

            if (command == null)
                return false;
            _unitOfWork.GetRepository<Command>().Delete(command);
            await _unitOfWork.CommitAsync();
            return true;
        }

        /// <summary>
        /// Adds the configuration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<List<DeviceConfig>> AddConfig(AddDeviceConfigRequest request)
        {
            var device = await _unitOfWork.GetRepository<Device>().FindAsync(x => x.Id == request.DeviceId);
            if (device == null)
                throw new Exception(ErrorMessages.NotFoundDevice);

            var applicationIds = request.DeviceConfigs.Select(x => x.ApplicationId);
            var versionIds = request.DeviceConfigs.Select(x => x.VersionId);

            var applications = _unitOfWork.GetRepository<Application>().GetAll().Where(x => applicationIds.Contains(x.Id));
            if (applications.Count() == 0)
                throw new Exception(ErrorMessages.NotFoundApplication);

            var versions = _unitOfWork.GetRepository<CS.EF.Models.Version>().GetAll().Where(x => versionIds.Contains(x.Id));

            if (versions.Count() == 0)
                throw new Exception(ErrorMessages.NotFoundVersion);

            var dictionApp = applications.ToDictionary(x => x.Id, x => x);
            var dictionVer = versions.ToDictionary(x => x.Id, x => x);

            var result = new List<DeviceConfig>();
            foreach (var item in request.DeviceConfigs)
            {
                var deviceConfig = new DeviceConfig
                {
                    ApplicationId = item.ApplicationId,
                    DeviceId = device.Id,
                    DeviceName = device.Name,
                    VersionId = item.VersionId,
                    ApplicationName = dictionApp.ContainsKey(item.ApplicationId) && dictionApp.Count > 0 ? dictionApp[item.ApplicationId].Name : "",
                    PackageName = dictionApp.ContainsKey(item.ApplicationId) && dictionApp.Count > 0 ? dictionApp[item.ApplicationId].PackageName : "",
                    VersionCode = dictionVer.ContainsKey(item.VersionId) && dictionVer.Count > 0 ? dictionVer[item.VersionId].Code : 0,
                    VersionName = dictionVer.ContainsKey(item.VersionId) && dictionVer.Count > 0 ? dictionVer[item.VersionId].Name : "",
                    LogTime = item.LogTime,
                    AreaCode = device.AreaCode,
                    CreatedBy = Systems.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = Systems.UpdatedBy,
                    UpdatedDate = DateTime.Now
                };
                _unitOfWork.GetRepository<DeviceConfig>().Add(deviceConfig);
                result.Add(deviceConfig);
            }
            await _unitOfWork.CommitAsync();
            return result;
        }

        /// <summary>
        /// Gets all configuration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<DeviceConfigResponse> GetAllConfig(DeviceConfigRequest request)
        {
            var deviceConfigs = _unitOfWork.GetRepository<DeviceConfig>().GetAll();

            if (!string.IsNullOrEmpty(request.DeviceName))
                deviceConfigs = deviceConfigs.Where(x => x.DeviceName.ToLower().Contains(request.DeviceName.ToLower()));

            if (!string.IsNullOrEmpty(request.ApplicationName))
                deviceConfigs = deviceConfigs.Where(x => x.ApplicationName.ToLower().Contains(request.ApplicationName.ToLower()));

            if (!string.IsNullOrEmpty(request.VersionName))
                deviceConfigs = deviceConfigs.Where(x => x.VersionName.ToLower().Contains(request.VersionName.ToLower()));

            if (!string.IsNullOrEmpty(request.AreaCode))
                deviceConfigs = deviceConfigs.Where(x => x.AreaCode == request.AreaCode);

            if (request.IsActive.HasValue)
                deviceConfigs = deviceConfigs.Where(x => x.IsActive == request.IsActive);

            var total = await deviceConfigs.CountAsync();

            var result = deviceConfigs.Skip(request.Skip).Take(request.Take).OrderByDescending(x => x.CreatedDate);

            return new DeviceConfigResponse
            {
                Total = total,
                Data = _mapper.Map<List<DeviceConfigViewModel>>(result)
            };
        }

        /// <summary>
        /// Verifies the device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<ImportDeviceResponse> VerifyDevice(List<ImportDeviceModel> request)
        {
            var verifyImport = new List<ImportDeviceData>();

            foreach (var item in request)
            {
                bool isVerify = true;
                List<string> reasons = new List<string>();
                DeviceType deviceType = DeviceType.KIOSK;
                if (string.IsNullOrEmpty(item.Name))
                {
                    reasons.Add("Tên thiết bị không được trống");
                    isVerify = false;
                }

                if (string.IsNullOrEmpty(item.Code))
                {
                    reasons.Add("Mã thiết bị không được trống");
                    isVerify = false;
                }

                if (!string.IsNullOrEmpty(item.Type))
                {
                    //if (item.Type.ToUpper() == "KIOSK")
                    //    deviceType = DeviceType.KIOSK;
                    if (item.Type.ToUpper() == "LCD")
                        deviceType = DeviceType.LCD;
                }
                var data = _mapper.Map<ImportDeviceData>(item);
                data.IsActive = !string.IsNullOrEmpty(item.IsActive) && (item.IsActive.ToUpper() == "HOẠT ĐỘNG" || item.IsActive.ToUpper() == "ACTIVE");
                data.Reasons = reasons;
                data.IsVerify = isVerify;
                data.Type = deviceType;
                verifyImport.Add(data);
            }

            return new ImportDeviceResponse
            {
                Import = verifyImport,
                Total = verifyImport.Count
            };
        }

        /// <summary>
        /// Processes the import.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<bool> ProcessImport(ProcessImportDeviceRequest request)
        {
            foreach (var item in request.Imports)
            {
                var device = _mapper.Map<Device>(item);
                _unitOfWork.GetRepository<Device>().Add(device);
            }

            await _unitOfWork.CommitAsync();
            return true;
        }

        /// <summary>
        /// Scans the device.
        /// </summary>
        public async Task ScanDevice()
        {
            var devices = _unitOfWork.GetRepository<Device>().GetAll().Where(x => x.IsActive);

            var deviceOff = new List<Device>();

            foreach (var device in devices)
            {
                var seconds = (DateTime.Now - device.UpdatedDate).TotalSeconds;
                if (seconds >= _settings.Setting.TimeOut)
                {
                    deviceOff.Add(device);
                }
            }

            if (deviceOff.Count > 0)
            {
                await _emailSender.SendEmailDevice(deviceOff);
            }
        }
    }
}
