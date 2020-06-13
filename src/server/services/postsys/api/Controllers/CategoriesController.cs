using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ncc.China.Http;
using Ncc.China.Services.Postsys.Logic;
using Ncc.China.Services.Postsys.Logic.Dto;
using Ncc.China.Services.Postsys.Repository;

namespace Ncc.China.Services.Postsys.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CategoryCreateDto dto)
        {
            var res = new CategoryService(_categoryRepository).CreateCategory(dto);
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return BadRequest(res);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await new CategoryService(_categoryRepository).GetCategorys();
            if (res.Code == MessageStatusCode.Succeeded) return Ok(res);
            return BadRequest(res);
        }
    }
}
