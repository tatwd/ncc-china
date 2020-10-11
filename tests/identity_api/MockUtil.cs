using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ncc.China.Common;
using Ncc.China.Services.Identity.Data;

namespace Ncc.China.Services.Identity.Api.Test
{
    public class MockUtil
    {
        public static IdentityDbContext CreateIdentityDbContext()
        {
            // 随机生成不同数据库上下文
            // 防止同一上下文 Dispose 造成运行时异常
            var databaseName = $"identity_api_test_db({Guid.NewGuid()})";
            var options = new DbContextOptionsBuilder<IdentityDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
            var mockContext = new IdentityDbContext(options);
            if (!mockContext.LoginUsers.Any())
            {
                var salt = CryptoUtil.CreateSalt(10);
                var encodePwd = CryptoUtil.Encrypt("test123", salt);
                var users = new []
                {
                    new LoginUser
                    {
                        Id = "329527ba9c344871a7d7f97ade476065",
                        Username = "test",
                        Email = "test@test.com",
                        Password = encodePwd,
                        Salt = salt,
                        UtcCreated = DateTime.UtcNow,
                        UtcUpdated = DateTime.UtcNow,
                    },
                    new LoginUser
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        Username = "bar",
                        Email = "bar@test.com",
                        Password = encodePwd,
                        Salt = salt,
                        UtcCreated = DateTime.UtcNow,
                        UtcUpdated = DateTime.UtcNow,
                    }
                };
                var userProfiles = new []
                {
                    new UserProfile{UserId = users[0].Id},
                    new UserProfile{UserId = users[1].Id}
                };
                mockContext.LoginUsers.AddRange(users);
                mockContext.UserProfiles.AddRange(userProfiles);
                mockContext.SaveChanges();
            }
            return mockContext;
        }

    }
}
