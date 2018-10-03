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
            var service = new UserService(_context);
            return Ok(service.Login(dto));
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody]RegisterDto dto)
        {
            var service = new UserService(_context);
            return Ok(service.Register(dto));
        }
    }
}
