using System;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ncc.China.Services.Identity.Data;

namespace Ncc.China.Services.Identity.Logic.Dto
{
    public class SimpleUserInfoDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime UtcCreated { get; set; }
        public string AvatarUrl { get; set; }
        public Gender? Gender { get; set; }
        public string Bio { get; set; }
        public string Nickname { get; set; }


        private bool _isEmpty;
        public bool IsEmpty() => _isEmpty;

        public static SimpleUserInfoDto Empty => new SimpleUserInfoDto {_isEmpty = true};

    }
}
