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
        public async Task<BaseResponseMessage> Get()
        {
            var service = new PostService(_postRepository);
            return await service.GetPosts();
        }
    }
}
