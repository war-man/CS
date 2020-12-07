using AutoMapper;
using CS.Common.Common;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    public class DeviceController : ControllerBase
    {
        /// <summary>
        /// The device service
        /// </summary>
        private readonly IDeviceService _deviceService;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// The settings
        /// </summary>
        private readonly Settings _settings;
        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IDeviceConfigService _deviceConfigService;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceController"/> class.
        /// </summary>
        /// <param name="deviceService">The device service.</param>
        /// <param name="versionService">The version service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="settings">The settings.</param>
        public DeviceController(IDeviceService deviceService,
            IMapper mapper,
            Settings settings,
            IHttpContextAccessor httpContextAccessor,
            IDeviceConfigService deviceConfigService)
        {
            _deviceService = deviceService;
            _mapper = mapper;
            _settings = settings;
            _httpContextAccessor = httpContextAccessor;
            _deviceConfigService = deviceConfigService;
        }

        #region Device
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var device = await _deviceService.GetAsync(id);
            if (device == null)
                throw new Exception(ErrorMessages.NotFoundDevice);

            var response = _mapper.Map<DeviceViewModel>(device);
            //response.Version = _mapper.Map<VersionViewModel>(device.Version);
            //response.Version.Apk = _mapper.Map<ApkViewModel>(device.Version.Apk);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Gets the ip.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet, Route("get/{ip}")]
        public async Task<IActionResult> GetIp(string ip)
        {
            var device = await _deviceService.FindAsync(x => x.Ip == ip);
            if (device == null)
                throw new Exception(ErrorMessages.NotFoundDevice);

            var response = _mapper.Map<DeviceViewModel>(device);
            //response.Version = _mapper.Map<VersionViewModel>(device.Version);
            //response.Version.Apk = _mapper.Map<ApkViewModel>(device.Version.Apk);

            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Adds the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost, Route("add-or-update")]
        public async Task<IActionResult> Add(AddOrUpdateDeviceRequest request)
        {
            var response = await _deviceService.AddOrUpdateDevice(request);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetDeviceRequest request)
        {
            var devices = await _deviceService.GetAll(request);
            return Ok(new ApiOkResponse(devices));
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost, Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var device = await _deviceService.GetAsync(id);
            if (device == null)
                throw new Exception(ErrorMessages.NotFoundDevice);

            var deviceConfigs = await _deviceConfigService.FindAllAsync(x => x.DeviceId == device.Id);

            if (deviceConfigs.Count > 0)
                throw new Exception(ErrorMessages.CanNotDeleteDevice);

            await _deviceService.DeleteAsync(id);
            return Ok(new ApiOkResponse(true));
        }

        /// <summary>
        /// Gets all device.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("app/all")]
        public async Task<IActionResult> GetAllDevice()
        {
            var devices = await _deviceService.GetAllAsync();

            var devicesView = new List<DeviceViewModel>();
            foreach (var item in devices)
            {
                var response = _mapper.Map<DeviceViewModel>(item);
                //response.Version = _mapper.Map<VersionViewModel>(item.Version);
                //response.Version.Apk = _mapper.Map<ApkViewModel>(item.Version.Apk);
                devicesView.Add(response);
            }
            return Ok(new ApiOkResponse(devicesView));
        }

        /// <summary>
        /// Checks the device.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet, Route("check/{deviceId}")]
        public async Task<IActionResult> CheckDevice(Guid deviceId)
        {
            var device = await _deviceService.FindAsync(x => x.Id == deviceId);

            if (device == null)
                throw new Exception(ErrorMessages.NotFoundDevice);

            device.UpdatedDate = DateTime.Now;
            await _deviceService.UpdateAsync(device, deviceId);
            return Ok();
        }
        #endregion

        #region Device Export
        [HttpPost, Route("import")]
        public async Task<IActionResult> ImportAndVerify(IFormFile ExcelFile)
        {
            var devices = new List<ImportDeviceModel>();
            var stream = new MemoryStream();
            await ExcelFile.CopyToAsync(stream);
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var columnCount = worksheet.Dimension.Columns;

                if (columnCount != 6 || rowCount >= 100 || rowCount <= 1)
                {
                    throw new Exception("InvalidColum");
                }
                for (int row = 6; row <= rowCount; row++)
                {
                    var deviceName = worksheet.Cells[row, 2].Value?.ToString().Trim().Replace("'", "");
                    var deviceCode = worksheet.Cells[row, 3].Value?.ToString().Trim().Replace("'", "");
                    var ip = worksheet.Cells[row, 4].Value?.ToString().Trim().Replace("'", "");
                    var areaCode = worksheet.Cells[row, 5].Value?.ToString().Trim().Replace("'", "");
                    var deviceType = worksheet.Cells[row, 6].Value?.ToString().Trim().Replace("'", "");
                    var isActive = worksheet.Cells[row, 7].Value?.ToString().Trim().Replace("'", "");
                    devices.Add(new ImportDeviceModel
                    {
                        Name = deviceName,
                        Type = deviceType,
                        AreaCode = areaCode,
                        Code = deviceCode,
                        Ip = ip,
                        IsActive = isActive,
                    });
                }
                var response = await _deviceService.VerifyDevice(devices);
                response.FileErrorUrl = GetFileError(response.Import);
                return Ok(new ApiOkResponse(response));
            }
        }
        [HttpPost, Route("proccess/import")]
        public async Task<IActionResult> ImportAndVerify([FromBody] ProcessImportDeviceRequest request)
        {
            var response = await _deviceService.ProcessImport(request);
            return Ok(new ApiOkResponse(response));
        }
        #endregion

        private string GetFileError(List<ImportDeviceData> datas)
        {
            var webRoot = "wwwroot/";
            var tempPath = @"templates/export_error.xlsx";

            int NUMBER_IGNORE_ROW = 6;
            FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
            if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

            var fileName = "export_error.xlsx";
            var exportFolder = Path.Combine(webRoot, "export");

            if (!Directory.Exists(exportFolder))
                Directory.CreateDirectory(exportFolder);

            var filePath = @"export/" + fileName;
            var fullPath = Path.Combine(webRoot, filePath);

            FileInfo file = new FileInfo(fullPath);

            if (file.Exists)
            {
                file.Delete();
                tempFile.CopyTo(fullPath);
            }
            else
                tempFile.CopyTo(fullPath);

            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet detailSheet = package.Workbook.Worksheets[0];

                if (datas.Count > 0)
                {
                    var row = NUMBER_IGNORE_ROW;
                    detailSheet.InsertRow(row + 2, datas.Count - 2, row + 1);
                    foreach (var item in datas)
                    {
                        if (!item.IsVerify)
                        {
                            detailSheet.Cells[row, 2, row, 7].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            detailSheet.Cells[row, 2, row, 7].Style.Fill.BackgroundColor.SetColor(Color.OrangeRed);
                        }
                        detailSheet.Cells["B" + row].Value = item.Name ?? "";
                        detailSheet.Cells["C" + row].Value = item.Code ?? "";
                        detailSheet.Cells["D" + row].Value = item.Ip ?? "";
                        detailSheet.Cells["E" + row].Value = item.AreaCode ?? "";
                        detailSheet.Cells["F" + row].Value = item.Type;
                        detailSheet.Cells["G" + row].Value = item.IsActive;
                        detailSheet.Cells["H" + row].Value = string.Join(", ", item.Reasons);
                        row++;
                    }
                    detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();
                }
                package.Save();
            }

            var scheme = _httpContextAccessor.HttpContext.Request.Scheme;
            var host = _httpContextAccessor.HttpContext.Request.Host;
            var pathBase = _httpContextAccessor.HttpContext.Request.PathBase;

            return $"{scheme}://{host}{pathBase}/{filePath}";
        }
    }
}
