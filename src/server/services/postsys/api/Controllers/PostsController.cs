using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ncc.China.Services.Postsys.Repository;
using Ncc.China.Services.Postsys.Logic;
using Ncc.China.Services.Postsys.Data;
using Ncc.China.Http.Message;

namespace Ncc.China.Services.Postsys.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await new PostService(_postRepository).GetPosts();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var res = await new PostService(_postRepository).GetPost(id);
            if (res.Code == Http.MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }
    }
}
