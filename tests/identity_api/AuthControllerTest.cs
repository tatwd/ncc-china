using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Ncc.China.Common;
using Ncc.China.Services.Identity.Logic;
using Ncc.China.Services.Identity.Api.Controllers;
using Ncc.China.Http;
using Ncc.China.Services.Identity.Logic.Dto;
using Ncc.China.Http.Message;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Ncc.China.Services.Identity.Data;

namespace Ncc.China.Services.Identity.Api.Test
{
    public class AuthControllerTest
    {
        private static AuthController CreateAuthController()
        {
            var mockContext = MockUtil.CreateIdentityDbContext();
            var mockUserService = new UserService(mockContext);
            var mockConfig = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Tokens:Issuer"] = "https://ncc.china",
                    ["Tokens:Audience"] = "https://ncc.china",
                    ["Tokens:SecurityKey"] = "this_is_a_test_security_key",
                })
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddTransient<UserService>((sp) => {
                    return new UserService(mockContext);
                })
                .BuildServiceProvider();

            var authController = new AuthController(mockConfig, mockUserService);
            authController.ControllerContext.HttpContext = new DefaultHttpContext
            {
                RequestServices = serviceProvider
            };

            return authController;
        }

        [Fact]
        public void test_register_succeeded()
        {
            var dto = new RegisterDto
            {
                Username = "user_b",
                Password = "test123",
                Email = "user_b@test.com"
            };
            var result = CreateAuthController().Post(dto) as OkObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }

        [Fact]
        public void test_register_failed()
        {
            var dto = new RegisterDto
            {
                Username = "test", // already register
                Password = "test123",
                Email = null
            };
            var result = CreateAuthController().Post(dto) as BadRequestObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Failed, obj.Code);
        }

        [Fact]
        public void test_login_by_username_succeeded()
        {
            var dto = new LoginDto
            {
                Login = "test",
                Password = "test123"
            };
            var result = CreateAuthController().Post(dto) as ObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }

        [Fact]
        public void test_login_by_email_succeeded()
        {
            var dto = new LoginDto
            {
                Login = "test@test.com",
                Password = "test123"
            };
            var result = CreateAuthController().Post(dto) as OkObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }

        [Fact]
        public async Task test_updatePassword_succeeded()
        {
            var authController = CreateAuthController();
            authController.HttpContext.Items["username"] = "test";
            var newPwd = new PasswordUpdateDto
            {
                Old = "test123",
                New = "test321",
            };
            var res = await authController.Post("update", newPwd);
            var result = res as OkObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }

    }
}
