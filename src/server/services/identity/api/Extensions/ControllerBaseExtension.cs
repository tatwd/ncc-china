using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Ncc.China.Services.Identity.Data;
using Ncc.China.Services.Identity.Logic;

namespace Ncc.China.Services.Identity.Api.Extensions
{
    public static class ControllerBaseExtension
    {
        /// <summary>
        /// Get current login user
        /// </summary>
        /// <param name="controllerBase"></param>
        /// <returns></returns>
        public static Task<LoginUser> GetAuthUser(this ControllerBase controllerBase)
        {
            var userService = controllerBase.HttpContext.RequestServices.GetService<UserService>();
            var username = controllerBase.HttpContext.Items["username"] as string;
            return userService.GetUserByIdOrUsernameOrEmail(username);
        }
    }
}
