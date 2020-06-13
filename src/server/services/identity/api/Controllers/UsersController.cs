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
        private readonly IdentityDbContext  _context;

        public UsersController(IdentityDbContext context)
        {
            _context = context;
        }

        private LoginUser GetUser()
        {
            var username = HttpContext.Items["username"] as string;
            return new UserService(_context).GetUserByIdOrUsernameOrEmail(username);
        }

        [Authorize]
        [HttpGet("api/user")]
        public IActionResult GetCurrentUser()
        {
            var username = HttpContext.Items["username"] as string;
            var user = new UserService(_context).GetUserByUsername(username); // TODO: support query by login name and id
            return Ok(user);
        }

        [Authorize]
        [HttpPut("api/user")]
        public IActionResult UpdateUserProfile([FromBody]UserProfileUpdateDto dto)
        {
            var currentUser = GetUser();
            var res = new UserService(_context).UpdateUserProfile(currentUser, dto);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            else return BadRequest(res);
        }

        [Authorize]
        [HttpGet("api/users")]
        public IActionResult GetFromQuery([FromQuery]string id)
        {
            return GetFromRoute(id);
        }

        [HttpGet("api/users/{id}")]
        public IActionResult GetFromRoute([FromRoute]string id)
        {
            var res = new UserService(_context).GetUser(id);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            else return NotFound(res);
        }
    }
}
