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
    public class DeviceConfigService : IDeviceConfigService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// The email sender
        /// </summary>
        private readonly IEmailSender _emailSender;
        /// <summary>
        /// The settings
        /// </summary>
        private readonly Settings _settings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceConfigService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="emailSender">The email sender.</param>
        /// <param name="settings">The settings.</param>
        public DeviceConfigService(IUnitOfWork unitOfWork, IMapper mapper,
            IEmailSender emailSender,
            Settings settings,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
            _settings = settings;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>DeviceConfig.</returns>
        public DeviceConfig Add(DeviceConfig entity)
        {
            _unitOfWork.GetRepository<DeviceConfig>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>DeviceConfig.</returns>
        public async Task<DeviceConfig> AddAsync(DeviceConfig entity)
        {
            _unitOfWork.GetRepository<DeviceConfig>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<DeviceConfig>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<DeviceConfig>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(DeviceConfig entity)
        {
            _unitOfWork.GetRepository<DeviceConfig>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<DeviceConfig>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(DeviceConfig entity)
        {
            _unitOfWork.GetRepository<DeviceConfig>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<DeviceConfig>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>DeviceConfig.</returns>
        public DeviceConfig Find(Expression<Func<DeviceConfig, bool>> match)
        {
            return _unitOfWork.GetRepository<DeviceConfig>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;DeviceConfig&gt;.</returns>
        public ICollection<DeviceConfig> FindAll(Expression<Func<DeviceConfig, bool>> match)
        {
            return _unitOfWork.GetRepository<DeviceConfig>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;DeviceConfig&gt;.</returns>
        public async Task<ICollection<DeviceConfig>> FindAllAsync(Expression<Func<DeviceConfig, bool>> match)
        {
            return await _unitOfWork.GetRepository<DeviceConfig>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>DeviceConfig.</returns>
        public async Task<DeviceConfig> FindAsync(Expression<Func<DeviceConfig, bool>> match)
        {
            return await _unitOfWork.GetRepository<DeviceConfig>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DeviceConfig.</returns>
        public DeviceConfig Get(Guid id)
        {
            return _unitOfWork.GetRepository<DeviceConfig>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;DeviceConfig&gt;.</returns>
        public ICollection<DeviceConfig> GetAll()
        {
            return _unitOfWork.GetRepository<DeviceConfig>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;DeviceConfig&gt;.</returns>
        public async Task<ICollection<DeviceConfig>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<DeviceConfig>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DeviceConfig.</returns>
        public async Task<DeviceConfig> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<DeviceConfig>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>DeviceConfig.</returns>
        public DeviceConfig Update(DeviceConfig entity, Guid id)
        {
            if (entity == null)
                return null;

            DeviceConfig existing = _unitOfWork.GetRepository<DeviceConfig>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<DeviceConfig>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>DeviceConfig.</returns>
        public async Task<DeviceConfig> UpdateAsync(DeviceConfig entity, Guid id)
        {
            if (entity == null)
                return null;

            DeviceConfig existing = await _unitOfWork.GetRepository<DeviceConfig>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<DeviceConfig>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion
        /// <summary>
        /// Gets the device configuration.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        public async Task<List<DeviceConfigViewModel>> GetDeviceConfig(Guid deviceId)
        {
            var deviceConfig = await _unitOfWork.GetRepository<DeviceConfig>().GetAll().Where(x => x.DeviceId == deviceId).AsNoTracking().ToListAsync();

            return _mapper.Map<List<DeviceConfigViewModel>>(deviceConfig);
        }

        /// <summary>
        /// Gets the device configuration.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <returns></returns>
        public async Task<DeviceConfigViewModel> GetDeviceConfig(Guid deviceId, string packageName)
        {
            var deviceConfig = await _unitOfWork.GetRepository<DeviceConfig>().FindAsync(x => x.DeviceId == deviceId && x.PackageName == packageName);
            return _mapper.Map<DeviceConfigViewModel>(deviceConfig);
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
                var existed = await _unitOfWork.GetRepository<DeviceConfig>().FindAsync(x => x.DeviceId == device.Id && x.ApplicationId == item.ApplicationId);
                if (existed != null)
                    throw new Exception(ErrorMessages.DeviceConfigHaveExist);

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
                    Message = item.Message,
                    AreaCode = device.AreaCode,
                    CreatedBy = Systems.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = Systems.UpdatedBy,
                    UpdatedDate = DateTime.Now,
                    IsActive = true
                };
                _unitOfWork.GetRepository<DeviceConfig>().Add(deviceConfig);
                result.Add(deviceConfig);
            }
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<DeviceConfigViewModel> UpdateConfig(UpdateDeviceCofigRequest request)
        {
            var config = await _unitOfWork.GetRepository<DeviceConfig>()
                .FindAsync(x => x.DeviceId == request.DeviceId &&
                                x.ApplicationId == request.ApplicationId);

            if (config == null) throw new Exception(ErrorMessages.NotFoundDeviceConfig);

            var version = await _unitOfWork.GetRepository<CS.EF.Models.Version>().FindAsync(x => x.Id == request.VersionId);

            if (version == null) throw new Exception(ErrorMessages.NotFoundVersion);

            config.VersionCode = version.Code;
            config.VersionId = version.Id;
            config.VersionName = version.Name;
            config.LogTime = request.LogTime;
            config.Message = request.Message;

            _unitOfWork.GetRepository<DeviceConfig>().Update(config);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<DeviceConfigViewModel>(config);
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
        /// Changes the active.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<List<DeviceConfig>> ChangeActive(ChangeActiveConfigRequest request)
        {
            var devicesConfig = _unitOfWork.GetRepository<DeviceConfig>().GetAll();

            if (request.Ids != null && request.Ids.Count > 0)
                request.Ids.ForEach(key =>
                {
                    devicesConfig = devicesConfig.Where(x => x.DeviceId == key.DeviceId && x.ApplicationId == key.ApplicationId);
                });

            if (!string.IsNullOrEmpty(request.AreaCode))
                devicesConfig = devicesConfig.Where(x => x.AreaCode == request.AreaCode);

            await devicesConfig.ForEachAsync(x =>
            {
                x.IsActive = request.IsActive;
                x.Message = request.Message;
                _unitOfWork.GetRepository<DeviceConfig>().Update(x);
            });
            await _unitOfWork.CommitAsync();

            return devicesConfig.ToList();
        }

        public async Task<List<ApplicationLog>> GetLogs(Guid deviceId, Guid applicationId)
        {
            var device = await _unitOfWork.GetRepository<Device>().FindAsync(x => x.Id == deviceId);
            if (device == null) throw new Exception(ErrorMessages.NotFoundDevice);

            var application = await _unitOfWork.GetRepository<Application>().FindAsync(x => x.Id == applicationId);
            if (application == null) throw new Exception(ErrorMessages.NotFoundApplication);

            var logs = await _unitOfWork.GetRepository<ApplicationLog>().GetAll().Where(x => x.ApplicationId == applicationId && x.DeviceId == deviceId).ToListAsync();
            return logs;
        }

        public async Task<UploadLogsResponse> UploadLogs(Guid deviceId, Guid applicationId, List<IFormFile> logsFile)
        {
            var device = await _unitOfWork.GetRepository<Device>().FindAsync(x => x.Id == deviceId);
            if (device == null) throw new Exception(ErrorMessages.NotFoundDevice);

            var application = await _unitOfWork.GetRepository<Application>().FindAsync(x => x.Id == applicationId);
            if (application == null) throw new Exception(ErrorMessages.NotFoundApplication);

            var applicationLogs = new List<ApplicationLog>();
            if (logsFile.Count > 0)
            {
                var scheme = _httpContextAccessor.HttpContext.Request.Scheme;
                var host = _httpContextAccessor.HttpContext.Request.Host;
                var pathBase = _httpContextAccessor.HttpContext.Request.PathBase;

                foreach (var item in logsFile)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                    try
                    {
                        var folderName = @"Logs/";
                        var pathToSave = Path.Combine("wwwroot/", folderName);
                        Directory.CreateDirectory(pathToSave);

                        var fullPath = Path.Combine(pathToSave, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await item.CopyToAsync(stream);
                        }
                        var log = new ApplicationLog
                        {
                            Id = Guid.NewGuid(),
                            CreatedBy = Systems.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ApplicationId = application.Id,
                            DeviceId = device.Id,
                            Link = $"{scheme}://{host}{pathBase}/{folderName}{fileName}",
                            UpdatedBy = Systems.CreatedBy,
                            UpdatedDate = DateTime.Now
                        };
                        _unitOfWork.GetRepository<ApplicationLog>().Add(log);
                        applicationLogs.Add(log);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                await _unitOfWork.CommitAsync();
            }

            return new UploadLogsResponse
            {
                ApplicationLogs = applicationLogs
            };
        }

        public async Task<DeviceConfigViewModel> GetConfig(Guid deviceId, Guid applicationId)
        {
            var config = await _unitOfWork.GetRepository<DeviceConfig>().FindAsync(x => x.DeviceId == deviceId && x.ApplicationId == applicationId);
            if (config == null) throw new Exception(ErrorMessages.NotFoundDeviceConfig);
            return _mapper.Map<DeviceConfigViewModel>(config);
        }

        public async Task<bool> CheckDeviceConfig(Guid deviceId, Guid applicationId)
        {
            var deviceConfig = await _unitOfWork.GetRepository<DeviceConfig>().FindAsync(x => x.DeviceId == deviceId && x.ApplicationId == applicationId);
            if (deviceConfig == null)
                throw new Exception(ErrorMessages.NotFoundDevice);

            deviceConfig.UpdatedDate = DateTime.Now;
            _unitOfWork.GetRepository<DeviceConfig>().Update(deviceConfig);
            return await _unitOfWork.CommitAsync() == 1;
        }

        /// <summary>
        /// Scans the device configuration.
        /// </summary>
        public async Task ScanDeviceConfig()
        {
            var devicesConfig = _unitOfWork.GetRepository<DeviceConfig>().GetAll().Where(x => x.IsActive);

            var deviceOff = new List<DeviceConfig>();

            foreach (var device in devicesConfig)
            {
                var seconds = (DateTime.Now - device.UpdatedDate).TotalSeconds;
                if (seconds >= _settings.Setting.TimeOut)
                {
                    deviceOff.Add(device);
                }
            }

            if (deviceOff.Count > 0)
            {
                await _emailSender.SendEmailDeviceConfig(deviceOff);
            }
        }
    }
}
