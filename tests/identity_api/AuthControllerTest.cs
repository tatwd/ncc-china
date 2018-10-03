using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.AspNetCore.Mvc;

namespace Ncc.China.Services.Identity.Api.Test
{
    using Data;
    using Controllers;
    using Http;
    using Http.Message;
    using Logic.Dto;

    public class AuthControllerTest
    {
        private IdentityDbContext _context;
        private AuthController _controller;

        public AuthControllerTest()
        {
            var _options = new DbContextOptionsBuilder<IdentityDbContext>()
                .UseInMemoryDatabase(databaseName: "identity_api_test_db")
                .Options;
            _context = new IdentityDbContext(_options);
            _controller = new AuthController(_context);
        }

        [Fact]
        public void test_register_succeeded()
        {
            var dto = new RegisterDto
            {
                Username = "user_a",
                Password = "test123",
                Email = "user_a@test.com"
            };
            var result = _controller.Post(dto) as OkObjectResult;
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }


        [Fact]
        public void test_register_failed()
        {
            var dto = new RegisterDto
            {
                Username = "user_a", // already register
                Password = "test123",
                Email = null
            };
            var result = _controller.Post(dto) as OkObjectResult;
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
            var result = _controller.Post(dto) as OkObjectResult;
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
            var result = _controller.Post(dto) as OkObjectResult;
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }
    }
}
