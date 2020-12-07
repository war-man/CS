using CS.VM.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TEK.Core.App.Middleware;
using TEK.Core.Service.Interfaces;

namespace TEK.Core.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        /// <summary>
        /// The command service
        /// </summary>
        private readonly ICommandService _commandService;
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandController"/> class.
        /// </summary>
        /// <param name="commandService">The command service.</param>
        public CommandController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public async Task<IActionResult> AddCommand([FromBody] AddCommandRequest request)
        {
            var response = await _commandService.AddCommand(request);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        [HttpGet, Route("{deviceId}")]
        public async Task<IActionResult> GetCommand(Guid deviceId)
        {
            var response = await _commandService.GetCommand(deviceId);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <returns></returns>
        [HttpGet, Route("{deviceId}/{packageName}")]
        public async Task<IActionResult> GetCommand(Guid deviceId, string packageName)
        {
            var response = await _commandService.GetCommand(deviceId, packageName);
            return Ok(new ApiOkResponse(response));
        }

        /// <summary>
        /// Deletes the command.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="applicationId">The application identifier.</param>
        /// <returns></returns>
        [HttpPost, Route("{commandId}")]
        public async Task<IActionResult> DeleteCommand(Guid commandId)
        {
            var response = await _commandService.DeleteCommand(commandId);
            return Ok(new ApiOkResponse(response));
        }
    }
}
