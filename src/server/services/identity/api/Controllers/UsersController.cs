using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ncc.China.Http;
using Ncc.China.Http.Message;
using Ncc.China.Services.Identity.Data;
using Ncc.China.Services.Identity.Logic;
using Ncc.China.Services.Identity.Logic.Dto;

namespace Ncc.China.Services.Identity.Api.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        private LoginUser GetUser()
        {
            var username = HttpContext.Items["username"] as string;
            return _userService.GetUserByIdOrUsernameOrEmail(username);
        }

        [Authorize]
        [HttpGet("api/user")]
        public IActionResult GetCurrentUser()
        {
            using (_userService)
            {
                var username = HttpContext.Items["username"] as string;
                var res = _userService.GetSimpleUserInfoByIdOrUsernameOrEmail(username);
                return Ok(res);
            }
        }

        [Authorize]
        [HttpPut("api/user")]
        public IActionResult UpdateUserProfile([FromBody] UserProfileUpdateDto dto)
        {
            using (_userService)
            {
                var currentUser = GetUser();
                var res = _userService.UpdateUserProfile(currentUser, dto);
                if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
                else return BadRequest(res);
            }
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
            using (_userService)
            {
                var res = _userService.GetUser(id);
                if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
                else return NotFound(res);
            }
        }
    }
}
