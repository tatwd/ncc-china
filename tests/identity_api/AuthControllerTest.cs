using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Ncc.China.Common;

namespace Ncc.China.Services.Identity.Api.Test
{
    using Data;
    using Controllers;
    using Http;
    using Http.Message;
    using Logic.Dto;

    public class AuthControllerTest
    {
        private static AuthController CreateAuthController(bool initData = false)
        {
            // setup IdentityDbContext
            var options = new DbContextOptionsBuilder<IdentityDbContext>()
                .UseInMemoryDatabase(databaseName: "identity_api_test_db")
                .Options;
            var context = new IdentityDbContext(options);
            if (initData)
            {
                var salt = CryptoUtil.CreateSalt(10);
                var encode = CryptoUtil.Encrypt("test123", salt);
                var user = new LoginUser
                {
                    Username = "test",
                    Email = "test@test.com",
                    Password = encode,
                    Salt = salt,
                    UtcCreated = DateTime.UtcNow,
                    UtcUpdated = DateTime.UtcNow,
                };
                context.LoginUsers.Add(user);
                context.SaveChanges();
            }

            // setup IConfiguration
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Tokens:Issuer"] = "https://ncc.china",
                    ["Tokens:Audience"] = "https://ncc.china",
                    ["Tokens:SecurityKey"] = "this_is_a_test_security_key",
                })
                .Build();
            return new AuthController(context, config);
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
            var result = CreateAuthController(true).Post(dto) as BadRequestObjectResult;
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
            var result = CreateAuthController(true).Post(dto) as ObjectResult;
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
            var result = CreateAuthController(true).Post(dto) as OkObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }
    }
}
