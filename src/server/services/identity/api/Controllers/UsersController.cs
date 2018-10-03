using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ncc.China.Services.Identity.Api.Controllers
{
    using Data;
    using Logic;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IdentityDbContext  _context;

        public UsersController(IdentityDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFromQuery([FromQuery]string id)
        {
            var service = new UserService(_context);
            return Ok(service.GetUser(id));
        }

        [HttpGet("{id}")]
        public IActionResult GetFromRoute([FromRoute]string id)
        {
            var service = new UserService(_context);
            return Ok(service.GetUser(id));
        }
    }
}
