using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ncc.China.Services.Postsys.Repository;
using Ncc.China.Services.Postsys.Logic;
using Ncc.China.Services.Postsys.Data;
using Ncc.China.Http;
using Ncc.China.Http.Message;
using Ncc.China.Services.Postsys.Logic.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Ncc.China.Services.Postsys.Api.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostRepository _postRepository;
        private ICategoryRepository _categoryRepository;

        public PostsController(IPostRepository postRepository, ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
        }

        [Authorize]
        [HttpGet("api/user/posts")]
        public async Task<IActionResult> Get()
        {
            var username = HttpContext.Items["username"] as string;
            var service = new PostService(_postRepository, _categoryRepository);
            var res = await service.GetPosts(username);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }

        [HttpGet("api/users/{uid}/posts")]
        public async Task<IActionResult> GetByUserId([FromRoute]string uid)
        {
            var res = await new PostService(_postRepository, _categoryRepository).GetPosts(uid);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }

        [HttpGet("api/posts")]
        public async Task<IActionResult> Get([FromQuery]string query, [FromQuery]string type, [FromQuery]PostPaginateByCategoryDto dto)
        {
            BaseResponseMessage res;
            var service = new PostService(_postRepository, _categoryRepository);
            if (type == "hot") {
                res = await service.GetHotPosts();
            }
            else if (!string.IsNullOrEmpty(query))
            {
                res = await service.GetPosts(query, dto);
            }
            else
            {
                // res = !dto.IsValid
                //     ? await service.GetPosts()
                //     : await service.GetPosts(dto);
                res = await service.GetPosts(dto);
            }
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }

        [HttpGet("api/posts/{id}")]
        public async Task<IActionResult> Get([FromRoute]string id)
        {
            var res = await new PostService(_postRepository, _categoryRepository).GetPost(id);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }

        [HttpPost("api/posts")]
        public IActionResult Post([FromBody]PostCreateDto dto)
        {
            var res = new PostService(_postRepository).CreatePost(dto);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }

        [HttpDelete("api/posts/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute]string id)
        {
            var res = await new PostService(_postRepository).DeletePost(id);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return NotFound(res);
        }
    }
}
