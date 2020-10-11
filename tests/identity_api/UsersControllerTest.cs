using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Ncc.China.Common;
using Ncc.China.Services.Identity.Logic.Dto;
using Ncc.China.Services.Identity.Api.Controllers;
using Ncc.China.Services.Identity.Data;
using Ncc.China.Http.Message;
using Ncc.China.Http;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Ncc.China.Services.Identity.Logic;
using System.Linq;

namespace Ncc.China.Services.Identity.Api.Test
{
    public class UsersControllerTest
    {
        private static UsersController CreateUsersController(bool isLogged = false)
        {
            var mockContext = MockUtil.CreateIdentityDbContext();
            var mockUserService = new UserService(mockContext);
            var mockController = new UsersController(mockUserService);
            mockController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext{}
            };
            if (isLogged)
            {
                mockController.HttpContext.Items["username"] = "test";
            }

            return mockController;
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

        [Fact]
        public void GetCurrentUser_Ok()
        {
            var result = CreateUsersController(true).GetCurrentUser() as OkObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }

        [Fact]
        public void GetCurrentUser_Fail()
        {
            var result = CreateUsersController().GetCurrentUser() as OkObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Failed, obj.Code);
        }

        [Fact]
        public void UpdateUserProfile_Ok()
        {
            var dto = new UserProfileUpdateDto
            {
                Username = "foo",
                Email = "foo@test.com",
                Nickname = "Haha",
                AvatarUrl = "http://foo.com/img/avatar.jpg",
                Bio = "foo user",
                Gender = Gender.Male
            };
            var result = CreateUsersController(true).UpdateUserProfile(dto) as OkObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal(MessageStatusCode.Succeeded, obj.Code);
        }

        [Fact]
        public void UpdateUserProfile_Fail_WithSameUsername()
        {
            var dto = new UserProfileUpdateDto
            {
                Username = "bar",
                Email = "foo@test.com",
                Nickname = "Haha",
                AvatarUrl = "http://foo.com/img/avatar.jpg",
                Bio = "bar user",
                Gender = Gender.Male
            };
            var result = CreateUsersController(true).UpdateUserProfile(dto) as BadRequestObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal("failed:用户名已被占用", obj.Message);
        }

        [Fact]
        public void UpdateUserProfile_Fail_WithSameEmail()
        {
            var dto = new UserProfileUpdateDto
            {
                Username = "foo",
                Email = "bar@test.com",
                Nickname = "Haha",
                AvatarUrl = "http://foo.com/img/avatar.jpg",
                Bio = "bar user",
                Gender = Gender.Male
            };
            var result = CreateUsersController(true).UpdateUserProfile(dto) as BadRequestObjectResult;
            Assert.NotNull(result);
            var obj = result.Value as BaseResponseMessage;
            Assert.NotNull(obj);
            Assert.Equal("failed:邮箱已被占用", obj.Message);
        }
    }
}
