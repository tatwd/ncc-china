using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Ncc.China.Common;

namespace Ncc.China.Services.Identity.Api.Test
{
    using Data;
    using Controllers;
    using Http;
    using Http.Message;

    public class UsersControllerTest
    {
        private static UsersController CreateUsersController()
        {
            var options = new DbContextOptionsBuilder<IdentityDbContext>()
                .UseInMemoryDatabase(databaseName: "identity_api_test_db")
                .Options;
            var context = new IdentityDbContext(options);
            var salt = CryptoUtil.CreateSalt(10);
            var encode = CryptoUtil.Encrypt("test123", salt);
            var user = new LoginUser
            {
                Id = "329527ba9c344871a7d7f97ade476065",
                Username = "test",
                Email = "test@test.com",
                Password = encode,
                Salt = salt,
                UtcCreated = DateTime.UtcNow,
                UtcUpdated = DateTime.UtcNow,
            };
            context.LoginUsers.Add(user);
            context.SaveChanges();

            return new UsersController(context);
        }

        [Fact]
        public void test_get_user_by_id()
        {
            var result = CreateUsersController().GetFromRoute(
                id: "329527ba9c344871a7d7f97ade476065") as OkObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }
    }
}
