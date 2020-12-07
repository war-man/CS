using AutoMapper;
using CS.Common.Common;
using CS.VM.Models;
using CS.VM.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.App.Middleware;
using TEK.Core.Service.Interfaces;

namespace TEK.Core.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        /// <summary>
        /// The version service
        /// </summary>
        private readonly IVersionService _versionService;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IBundleService _bundleService;
        private readonly IDeviceConfigService _deviceConfigService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionController"/> class.
        /// </summary>
        /// <param name="versionService">The version service.</param>
        /// <param name="apkService">The apk service.</param>
        /// <param name="mapper">The mapper.</param>
        public VersionController(IVersionService versionService,
            IMapper mapper,
            IBundleService bundleService,
            IDeviceConfigService deviceConfigService)
        {
            _versionService = versionService;
            _mapper = mapper;
            _bundleService = bundleService;
            _deviceConfigService = deviceConfigService;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var version = await _versionService.GetAsync(id);
            if (version == null)
                throw new Exception(ErrorMessages.NotFoundVersion);

            var response = _mapper.Map<VersionViewModel>(version);
            response.Bundles = _mapper.Map<List<BundleViewModel>>(version.Bundles);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Adds the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost, Route("add-or-update"), DisableRequestSizeLimit]
        public async Task<IActionResult> Add([FromForm] AddOrUpdateVersionRequest request)
        {
            //var version = await _versionService.FindAsync(x => x.Id == request.Id);

            //if (version == null)
            //{
            //    var bundle = await _bundleService.UploadFile(request);
            //    var newVersion = _mapper.Map<CS.EF.Models.Version>(request);
            //    newVersion.Bundles.Add(bundle);
            //    await _versionService.AddAsync(newVersion);
            //    version = newVersion;
            //}
            //else
            //{
            //    version.Code = request.Code;
            //    version.Name = request.Name;
            //    version.UpdatedDate = DateTime.Now;
            //    await _versionService.UpdateAsync(version, version.Id);
            //}
            //var response = _mapper.Map<VersionViewModel>(version);
            //response.Bundles = _mapper.Map<List<BundleViewModel>>(version.Bundles);

            var response = await _versionService.AddOrUpdateVersion(request);

            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetVersionRequest request)
        {
            var response = await _versionService.GetAll(request);
            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var version = await _versionService.GetAsync(id);

            if (version == null)
                throw new Exception(ErrorMessages.NotFoundVersion);

            var deviceConfigs = await _deviceConfigService.FindAllAsync(x => x.VersionId == version.Id);

            if (deviceConfigs.Count > 0)
                throw new Exception(ErrorMessages.CanNotDeleteVersion);

            var response = await _versionService.DeleteAsync(version) == 1;

            return Ok(new ApiOkResponse(response));

        }
    }
}
