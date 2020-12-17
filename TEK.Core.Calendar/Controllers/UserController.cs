using CS.VM.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.App.Middleware;
using TEK.Core.Service.Interfaces;

namespace TEK.Core.Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn(AuthenticateRequest model)
        {
            var response = await _userService.LogIn(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpGet("all-users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();

            return Ok(new ApiOkResponse(users));
        }

        [HttpPost("add-new-user")]
        public async Task<IActionResult> AddNewUser(AddNewUserRequest request)
        {
            var response = await _userService.AddNewUser(request);
            return Ok(new ApiOkResponse(response));
        }
    }
}
