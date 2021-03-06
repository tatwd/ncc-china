using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Ncc.China.Services.Identity.Api.Extensions;

namespace Ncc.China.Services.Identity.Api.Controllers
{
    using Data;
    using Http;
    using Http.Message;
    using Logic;
    using Logic.Dto;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserService _userService;

        public AuthController(IConfiguration configuration,
            UserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] LoginDto dto)
        {
            var currentUser = _userService.Login(dto);
            var tokenManager = Util.GenerateJwt(currentUser.Id,
                _configuration["Tokens:Issuer"],
                _configuration["Tokens:Audience"],
                DateTime.UtcNow.AddMinutes(30),  // expired after 30 minutes.
                _configuration["Tokens:SecurityKey"]);
            return Ok(R.Ok.Create(new {currentUser, tokenManager}));
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody]RegisterDto dto)
        {
            var res = _userService.Register(dto);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return BadRequest(res);
        }

        [Authorize]
        [HttpPut("password")]
        public async Task<IActionResult> Post([FromQuery] string type, [FromBody] PasswordUpdateDto dto)
        {
            if (!type.Equals("update", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(R.Ko.Create($"不支持 `type={type}` 的请求"));
            }

            var currentUser = await this.GetAuthUser();
            var res = _userService.UpdatePassword(currentUser, dto);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return BadRequest(res);
        }



    }
}
