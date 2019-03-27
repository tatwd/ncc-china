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
        private IdentityDbContext  _context;
        private IConfiguration _configuration;

        public AuthController(IdentityDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody]LoginDto dto)
        {
            var res = new UserService(_context).Login(dto, () =>
            {
                var claims = new []{
                    new Claim(JwtRegisteredClaimNames.Sub, dto.Login), // TODO: save user id
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration["Tokens:SecurityKey"]));

                var jwt = new JwtSecurityToken(
                    issuer: _configuration["Tokens:Issuer"],
                    audience: _configuration["Tokens:Audience"],
                    expires: DateTime.UtcNow.AddMinutes(30), // expired after 30 minutes.
                    claims:claims,
                    signingCredentials: new SigningCredentials(signingKey,
                        SecurityAlgorithms.HmacSha256)
                );
                var token = new JwtSecurityTokenHandler()
                    .WriteToken(jwt);
                return new { token, type = "Bearer", expireAt = jwt.ValidTo };
            });
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return BadRequest(res);
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody]RegisterDto dto)
        {
            var res = new UserService(_context).Register(dto);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            else return BadRequest(res);
        }

        [Authorize]
        [HttpPut("password")]
        public IActionResult Post([FromQuery] string type, [FromBody] PasswordUpdateDto dto)
        {
            var currentUser = GetUser();
            var res = type.Equals("update")
                ? new UserService(_context).UpdatePassword(currentUser, dto)
                : new FailedResponseMessage($"不支持 `type={type}` 的请求");
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            else return BadRequest(res);
        }

        private LoginUser GetUser()
        {
            var username = HttpContext.Items["username"] as string;
            return new UserService(_context).GetUserByIdOrUsernameOrEmail(username);
        }
    }
}
