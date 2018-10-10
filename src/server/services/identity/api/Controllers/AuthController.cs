using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ncc.China.Services.Identity.Api.Controllers
{
    using Data;
    using Logic;
    using Logic.Dto;
    using Http;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IdentityDbContext  _context;

        public AuthController(IdentityDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody]LoginDto dto)
        {
            var res = new UserService(_context).Login(dto);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            else return BadRequest(res);
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody]RegisterDto dto)
        {
            var res = new UserService(_context).Register(dto);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            else return BadRequest(res);
        }
    }
}
