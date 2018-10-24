using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ncc.China.Services.Postsys.Repository;
using Ncc.China.Services.Postsys.Logic;
using Ncc.China.Services.Postsys.Data;
using Ncc.China.Http.Message;
using Ncc.China.Services.Postsys.Logic.Dto;

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
        public async Task<IActionResult> Get([FromQuery]PostPaginateByCategoryDto dto)
        {
            var service = new PostService(_postRepository);
            var res = !dto.IsValid
                ? await service.GetPosts()
                : await service.GetPosts(dto);
            if (res.Code == Http.MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var res = await new PostService(_postRepository).GetPost(id);
            if (res.Code == Http.MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }

        [HttpPost]
        public IActionResult Post([FromBody]PostCreateDto dto)
        {
            var res = new PostService(_postRepository).CreatePost(dto);
            if (res.Code == Http.MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }
    }
}
