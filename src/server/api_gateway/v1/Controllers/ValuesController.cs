using Microsoft.AspNetCore.Mvc;

namespace Ncc.China.ApiGateway.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                api_values_url = new {
                    info = "获取所有 API 地址信息",
                    http = "http://localhost:6660/api/v1/values",
                    https = "https://localhost:6661/api/v1/values",
                    methods = new [] { "GET" }
                },
                api_login_url = new {
                    info = "登录并返回 Token 及用户信息",
                    http = "http://localhost:6660/api/v1/auth/login",
                    https = "https://localhost:6661/api/v1/auth/login",
                    methods = new [] { "POST" }
                },
                api_register_url = new {
                    info = "注册，成功则用户 ID",
                    http = "http://localhost:6660/api/v1/auth/register",
                    https = "https://localhost:6661/api/v1/auth/register",
                    methods = new [] { "POST" }
                },
                api_users_url = new {
                    info = "根据用户 ID 查询对应记录",
                    http = "http://localhost:6660/api/v1/users{/user_id}",
                    https = "https://localhost:6661/api/v1/users{/user_id}",
                    methods = new [] { "GET" }
                },
                api_posts_url = new {
                    info = "创建帖子或根据帖子 ID 查询对应记录",
                    http = "http://localhost:6660/api/v1/posts{/post_id}",
                    https = "https://localhost:6661/api/v1/posts{/post_id}",
                    methods = new [] { "POST", "GET" }
                },
                api_posts_query_url = new {
                    info = "根据类别名分页查询帖子",
                    http = "http://localhost:6660/api/v1/posts?page={int}&limit={int}&category={string}&desc={bool}",
                    https = "https://localhost:6661/api/v1/posts?page={int}&limit={int}&category={string}&desc={bool}",
                    methods = new [] { "GET" }
                },
                api_categories_url = new {
                    info = "创建分类或获取所有分类",
                    http = "http://localhost:6660/api/v1/categories",
                    https = "https://localhost:6661/api/v1/categories",
                    methods = new [] { "POST", "GET" }
                },
            });
        }
    }
}
