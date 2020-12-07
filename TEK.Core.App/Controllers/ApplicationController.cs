using AutoMapper;
using CS.Common.Common;
using CS.VM.Models;
using CS.VM.Request;
using Microsoft.AspNetCore.Http;
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
    public class ApplicationController : ControllerBase
    {
        /// <summary>
        /// The application service
        /// </summary>
        private readonly IApplicationService _applicationService;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// The device configuration service
        /// </summary>
        private readonly IDeviceConfigService _deviceConfigService;
        /// <summary>
        /// The settings
        /// </summary>
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationController"/> class.
        /// </summary>
        /// <param name="applicationService">The application service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="settings">The settings.</param>
        public ApplicationController(IApplicationService applicationService,
            IMapper mapper,
            IDeviceConfigService deviceConfigService)
        {
            _applicationService = applicationService;
            _mapper = mapper;
            _deviceConfigService = deviceConfigService;
        }

        /// <summary>
        /// Adds the or update application.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost, Route("add-or-update")]
        public async Task<IActionResult> AddOrUpdateApplication(AddOrUpdateApplicationRequest request)
        {
            var response = await _applicationService.AddOrUpdateApplication(request);
            return Ok(new ApiOkResponse(response));
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetApplicationRequest request)
        {
            var response = await _applicationService.GetAll(request);
            return Ok(new ApiOkResponse(response));
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The application identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var application = await _applicationService.GetAsync(id);

            if (application == null)
                throw new Exception(ErrorMessages.NotFoundApplication);

            var response = _mapper.Map<ApplicationViewModel>(application);
            var versions = _mapper.Map<List<VersionViewModel>>(application.Versions);

            var bundles = application.Versions.SelectMany(x => x.Bundles);

            var dictionBundles = bundles.ToDictionary(x => x.VersionId, x => x);

            foreach (var version in versions)
            {
                var listBundle = new List<BundleViewModel>();
                if (dictionBundles.ContainsKey(version.Id))
                    listBundle.Add(_mapper.Map<BundleViewModel>(dictionBundles[version.Id]));
                version.Bundles = listBundle;
            }
            response.Versions = versions;

            return Ok(new ApiOkResponse(response));
        }

        [HttpPost, Route("{id}")]
        public async Task<IActionResult> DeleteApplication(Guid id)
        {
            var application = await _applicationService.GetAsync(id);
            if (application == null) throw new Exception(ErrorMessages.NotFoundApplication);

            var deviceConfigs = await _deviceConfigService.FindAllAsync(x => x.ApplicationId == application.Id);

            if (deviceConfigs.Count > 0)
                throw new Exception(ErrorMessages.CanNotDeleteApplication);

            var response = await _applicationService.DeleteAsync(application) == 1;
            return Ok(new ApiOkResponse(response));
        }
    }
}