using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Ncc.China.Http;
using Ncc.China.Http.Message;
using Ncc.China.Services.Identity.Api.Extensions;
using Ncc.China.Services.Identity.Data;
using Ncc.China.Services.Identity.Logic;
using Ncc.China.Services.Identity.Logic.Dto;

namespace Ncc.China.Services.Identity.Api.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("api/user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var username = HttpContext.Items["username"] as string;
            var data = await _userService.GetSimpleUserInfoByIdOrUsernameOrEmail(username);
            return Ok(data.IsEmpty() ? R.Ko.Create("未找到该用户") : R.Ok.Create(data));
        }

        [Authorize]
        [HttpPut("api/user")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserProfileUpdateDto dto)
        {
            var currentUser = await this.GetAuthUser();
            var res = _userService.UpdateUserProfile(currentUser, dto);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return BadRequest(res);
        }

        [Authorize]
        [HttpGet("api/users")]
        public IActionResult GetFromQuery([FromQuery] string id)
        {
            return GetFromRoute(id);
        }

        [Authorize]
        [HttpGet("api/users/{id}")]
        public IActionResult GetFromRoute([FromRoute] string id)
        {
            var res = _userService.GetUser(id);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }
    }
}
