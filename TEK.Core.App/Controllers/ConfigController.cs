using CS.Common.Common;
using CS.VM.Models;
using CS.VM.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TEK.Core.App.Middleware;
using TEK.Core.Service.Interfaces;

namespace TEK.Core.App.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        /// <summary>
        /// The device configuration service
        /// </summary>
        private readonly IDeviceConfigService _deviceConfigService;
        /// <summary>
        /// The settings
        /// </summary>
        private readonly Settings _settings;
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigController"/> class.
        /// </summary>
        /// <param name="deviceService">The device service.</param>
        public ConfigController(IDeviceConfigService deviceConfigService,
            Settings settings)
        {
            _deviceConfigService = deviceConfigService;
            _settings = settings;
        }

        #region Device Config
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <returns></returns>
        [HttpGet, Route("device/{deviceId}/packageName/{packageName}")]
        public async Task<IActionResult> GetConfig(Guid deviceId, string packageName)
        {
            var response = await _deviceConfigService.GetDeviceConfig(deviceId, packageName);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Gets the device configuration.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="applicationId">The application identifier.</param>
        /// <returns></returns>
        [HttpGet, Route("{deviceId}/{applicationId}")]
        public async Task<IActionResult> GetDeviceConfig(Guid deviceId, Guid applicationId)
        {
            var response = await _deviceConfigService.GetConfig(deviceId, applicationId);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        [HttpGet, Route("{deviceId}")]
        public async Task<IActionResult> GetConfig(Guid deviceId)
        {
            var response = await _deviceConfigService.GetDeviceConfig(deviceId);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Adds the configuration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public async Task<IActionResult> AddConfig(AddDeviceConfigRequest request)
        {
            var response = await _deviceConfigService.AddConfig(request);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Updates the configuration.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public async Task<IActionResult> UpdateConfig([FromBody] UpdateDeviceCofigRequest request)
        {
            var response = await _deviceConfigService.UpdateConfig(request);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Gets all configuration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public async Task<IActionResult> GetAllConfig([FromQuery] DeviceConfigRequest request)
        {
            var response = await _deviceConfigService.GetAllConfig(request);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Changes the active.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost, Route("change-active")]
        public async Task<IActionResult> ChangeActive([FromBody] ChangeActiveConfigRequest request)
        {
            var changeActive = await _deviceConfigService.ChangeActive(request);
            return Ok(new ApiOkResponse(changeActive));
        }

        /// <summary>
        /// Checks the device.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet, Route("check/{deviceId}/{applicationId}")]
        public async Task<IActionResult> CheckDevice(Guid deviceId, Guid applicationId)
        {
            var response = await _deviceConfigService.CheckDeviceConfig(deviceId, applicationId);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Gets the logs.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        [HttpGet, Route("logs/all/{deviceId}/{applicationId}")]
        public async Task<IActionResult> GetLogs(Guid deviceId, Guid applicationId)
        {
            var response = await _deviceConfigService.GetLogs(deviceId, applicationId);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Uploads the logs.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="logsFile">The logs file.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost, Route("upload/logs/{deviceId}/{applicationId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadLogs(Guid deviceId, Guid applicationId, List<IFormFile> logsFile)
        {
            var task = Task.Run(async () =>
            {
                return await _deviceConfigService.UploadLogs(deviceId, applicationId, logsFile);
            });

            bool isCompletedSuccessfully = task.Wait(TimeSpan.FromSeconds(_settings.Setting.TimeOut));

            if (isCompletedSuccessfully)
                return Ok(new ApiOkResponse(task.Result));
            else
                throw new Exception(ErrorMessages.FunctionTimeOut);
        }

        [HttpPost, Route("{deviceId}/{applicationId}")]
        public async Task<IActionResult> Delete(Guid deviceId, Guid applicationId)
        {
            var config = await _deviceConfigService.FindAsync(x => x.DeviceId == deviceId && x.ApplicationId == applicationId);
            if (config == null) throw new Exception(ErrorMessages.NotFoundDeviceConfig);
            var response = await _deviceConfigService.DeleteAsync(config) == 1;
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Testemails this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("test/send-mail")]
        public async Task<IActionResult> TESTEMAIL()
        {
            await _deviceConfigService.ScanDeviceConfig();
            return Ok();
        }
        #endregion

    }
}
