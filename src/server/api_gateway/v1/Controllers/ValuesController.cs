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
                api_values_url = new InnerApiUrl(
                    "api/v1/values",
                    "获取所有 API 地址信息",
                    "GET"),
                api_login_url = new InnerApiUrl(
                    "api/v1/auth/login",
                    "登录并返回 Token 及用户信息",
                    "POST"),
                api_register_url = new InnerApiUrl(
                    "v1/auth/register",
                    "注册，成功则用户 ID",
                    "POST"),
                api_current_user_password_url = new InnerApiUrl(
                    "v1/auth/password?type={string}",
                    "当 `type=update` 时为修改密码",
                    "PUT"),
                api_users_url = new InnerApiUrl(
                    "api/v1/users{/user_id}",
                    "根据用户 ID 查询对应记录或修改用户信息",
                    "GET", "PUT"),
                api_current_user_url = new InnerApiUrl(
                    "api/v1/user",
                    "获取当前用户的信息",
                    "GET"),
                api_posts_url = new InnerApiUrl(
                    "api/v1/posts{/post_id}",
                    "创建帖子或根据帖子 ID 查询对应记录",
                    "POST", "GET"),
                api_current_user_posts_url = new InnerApiUrl(
                    "api/v1/user/posts{/post_id}",
                    "获取当前用户的帖子或删除对应 ID 的帖子记录",
                    "GET", "DELETE"),
                api_hot_posts_url = new InnerApiUrl(
                    "api/v1/posts?type=hot",
                    "获取热门帖子",
                    "GET"),
                api_posts_query_url = new InnerApiUrl(
                    "api/v1/posts?page={int}&limit={int}&category={string}&desc={bool}",
                    "根据类别名分页查询帖子",
                    "GET"),
                api_posts_search_url = new InnerApiUrl(
                    "api/v1/posts?query={string}{&limit,category,desc}",
                    "搜索贴子，可根据类别名进行分页",
                    "GET"),
                api_categories_url = new InnerApiUrl(
                    "api/v1/categories",
                    "创建分类或获取所有分类",
                    "POST", "GET"),
                api_comments_url = new InnerApiUrl(
                    "api/v1/posts/{post_id}/comments",
                    "获取对应帖子 ID 的所有评论或创建评论",
                    "POST", "GET"),
                api_current_user_comments_url = new InnerApiUrl(
                    "api/v1/comments{/comment_id}",
                    "获取当前用户的评论或删除对应 ID 的评论",
                    "GET", "DELETE"),
            });
        }
    }

    public class InnerApiUrl
    {
        public string info { get; set; }
        public string http { get; set; }
        public string https { get; set; }
        public string[] methods { get; set; }

        public InnerApiUrl(string url, string info, params string[] methods)
        {
            this.info = info;
            this.http = string.Format("http://localhost:6660/{0}", url);
            this.https = string.Format("https://localhost:6661/{0}", url);
            this.methods = methods;
        }
    }
}
