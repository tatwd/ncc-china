using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Ncc.China.Services.Identity.Api.Controllers
{
    using Data;
    using Logic;
    using Http;
    using Http.Message;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IdentityDbContext  _context;

        public UsersController(IdentityDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetFromQuery([FromQuery]string id)
        {
            return GetFromRoute(id);
        }

        [HttpGet("{id}")]
        public IActionResult GetFromRoute([FromRoute]string id)
        {
            var res = new UserService(_context).GetUser(id);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            else return NotFound(res);
        }
    }
}
