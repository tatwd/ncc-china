using System;
using System.Collections.Generic;
using System.Linq;
using Ncc.China.Common;
using Ncc.China.Http.Message;
using Ncc.China.Services.Identity.Data;
using Ncc.China.Services.Identity.Logic.Dto;
using Microsoft.Extensions.Logging;

namespace Ncc.China.Services.Identity.Logic
{
    public class UserService : IDisposable
    {
        private readonly IdentityDbContext _context;

        public UserService(IdentityDbContext context)
        {
            _context = context;
        }

        public IList<LoginUser> GetUsers()
        {
            var users = _context.LoginUsers.Where(i => !i.IsDeleted).ToArray();
            return users;
        }

        public BaseResponseMessage GetUser(string id)
        {
            var user = _context.LoginUsers
                .FirstOrDefault(u => u.Id.Equals(id));
            if (user == null)
            {
                return new FailedResponseMessage("未找到该用户");
            }
            var userProfile = _context.UserProfiles
                .FirstOrDefault(u => u.UserId.Equals(user.Id));
            return new SucceededResponseMessage(new
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                UtcCreated = user.UtcCreated,
                AvatarUrl = userProfile?.AvatarUrl,
                Gender = userProfile?.Gender,
                Bio = userProfile?.Bio,
                Nickname = userProfile?.Nickname
            });
        }

        public LoginUser GetUserByIdOrUsernameOrEmail(string id_username_email)
        {
            var user = _context.LoginUsers
                .FirstOrDefault(u =>
                    u.Id.Equals(id_username_email) ||
                    u.Username.Equals(id_username_email) ||
                    u.Email.Equals(id_username_email)
                );
            return user;
        }

        public BaseResponseMessage GetSimpleUserInfoByIdOrUsernameOrEmail(string username)
        {
            var user = GetUserByIdOrUsernameOrEmail(username);
            if (user == null)
            {
                return new FailedResponseMessage("未找到该用户");
            }
            var userProfile = _context.UserProfiles
                .FirstOrDefault(u => u.UserId.Equals(user.Id));
            return new SucceededResponseMessage(new
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                UtcCreated = user.UtcCreated,
                AvatarUrl = userProfile?.AvatarUrl,
                Gender = userProfile?.Gender,
                Bio = userProfile?.Bio,
                Nickname = userProfile?.Nickname
            });
        }

        public BaseResponseMessage Login(LoginDto dto, Func<string, object> generateTokenFunc = null)
        {
            try
            {
                var user = _context.LoginUsers
                    .FirstOrDefault(u => u.Username.Equals(dto.Login) ||
                        u.Email.Equals(dto.Login));
                if (user == null)
                {
                    return new FailedResponseMessage("该用户还未注册");
                }
                var encode = CryptoUtil.Encrypt(dto.Password, user.Salt);
                if (!encode.Equals(user.Password))
                {
                    return new FailedResponseMessage("密码错误");
                }
                var userProfile = _context.UserProfiles
                    .FirstOrDefault(u => u.UserId.Equals(user.Id));
                var currentUser = new
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Nickname = userProfile?.Nickname,
                    Gender = userProfile?.Gender,
                    AvatarUrl = userProfile?.AvatarUrl,
                    UtcCreated = user.UtcCreated
                };
                if (generateTokenFunc == null) return new SucceededResponseMessage(currentUser);
                var tokenManager = generateTokenFunc(currentUser.Id);
                return new SucceededResponseMessage(new
                {
                    currentUser,
                    tokenManager,
                });
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public BaseResponseMessage Register(RegisterDto dto)
        {
            var hasUser = _context.LoginUsers
                .FirstOrDefault(u => u.Username.Equals(dto.Username));
            if (hasUser != null)
            {
                return new FailedResponseMessage("该用户名已注册");
            }

            hasUser = _context.LoginUsers
                .FirstOrDefault(u => u.Email.Equals(dto.Email));
            if (hasUser != null)
            {
                return new FailedResponseMessage("该邮箱已注册");
            }
            var salt = CryptoUtil.CreateSalt(10); // todo: 生成随机数计算
            var encode = CryptoUtil.Encrypt(dto.Password, salt);
            var user = new LoginUser
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = encode,
                Salt = salt,
                UtcCreated = DateTime.UtcNow,
                UtcUpdated = DateTime.UtcNow,
            };
            _context.LoginUsers.Add(user);

            // add some info to user_profile
            _context.UserProfiles.Add(new UserProfile
            {
                UserId = user.Id,
                AvatarUrl = "/test-avatar.jpeg",
            });

            if (_context.SaveChanges() <= 0)
            {
                return new FailedResponseMessage("数据库操作异常");
            }
            return new SucceededResponseMessage(user.Id);
        }

        public BaseResponseMessage UpdateUserProfile(LoginUser currentUser, UserProfileUpdateDto dto)
        {
            try
            {
                if (!currentUser.Username.Equals(dto.Username))
                {
                    if (_context.LoginUsers.Any(_ => _.Username.Equals(dto.Username)))
                    {
                        return new FailedResponseMessage("用户名已被占用");
                    }
                    else
                    {
                        currentUser.Username = dto.Username;
                    }
                }
                if (!currentUser.Email.Equals(dto.Email))
                {
                    if (_context.LoginUsers.Any(_ => _.Email.Equals(dto.Email)))
                    {
                        return new FailedResponseMessage("邮箱已被占用");
                    }
                    else
                    {
                        currentUser.Email = dto.Email;
                    }
                }

                currentUser.UtcUpdated = DateTime.UtcNow;

                var profile = _context.UserProfiles.FirstOrDefault(_ => _.UserId.Equals(currentUser.Id));
                profile.Nickname = dto.Nickname;
                profile.AvatarUrl = dto.AvatarUrl;
                profile.Gender = dto.Gender;
                profile.Bio = dto.Bio;
                profile.UtcUpdated = DateTime.UtcNow;

                _context.UpdateRange(currentUser, profile);
                if (_context.SaveChanges() > 0)
                {
                    return new SucceededResponseMessage(null, "ok");
                }
                return new FailedResponseMessage("数据库操作异常");
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }
        public BaseResponseMessage UpdatePassword(LoginUser user, PasswordUpdateDto dto)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            try
            {
                var encode = CryptoUtil.Encrypt(dto.Old, user.Salt);
                if (!encode.Equals(user.Password))
                {
                    return new FailedResponseMessage("原密码错误");
                }

                var salt = CryptoUtil.CreateSalt(10);
                user.Password = CryptoUtil.Encrypt(dto.New, salt);
                user.Salt = salt;
                user.UtcUpdated = DateTime.UtcNow;

                if (_context.SaveChanges() > 0)
                {
                    return new SucceededResponseMessage(null, "ok");
                }
                return new FailedResponseMessage("数据库操作异常");
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
