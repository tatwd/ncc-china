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

    public class UsersControllerTest
    {
        private IdentityDbContext _context;
        private UsersController _controller;

        public UsersControllerTest()
        {
            var _options = new DbContextOptionsBuilder<IdentityDbContext>()
                .UseInMemoryDatabase(databaseName: "identity_api_test_db")
                .Options;
            _context = new IdentityDbContext(_options);
            _controller = new UsersController(_context);

            var user = new LoginUser
            {
                Id = "329527ba9c344871a7d7f97ade476065",
                Username = "test",
                Email = "test@test.com",
                Password = "9e903b73945d1664cba79dd611f957642ea780d8cec04a4b6ad773d01843d2ed",
                Salt = "ewh45gwMpBPLYg==",
                UtcCreated = DateTime.UtcNow,
                UtcUpdated = DateTime.UtcNow
            };
            _context.LoginUsers.Add(user);
            _context.SaveChanges();
        }

        [Fact]
        public void test_get_user_by_id()
        {
            var result = _controller.GetFromRoute(
                id: "329527ba9c344871a7d7f97ade476065") as OkObjectResult;
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }
    }
}
