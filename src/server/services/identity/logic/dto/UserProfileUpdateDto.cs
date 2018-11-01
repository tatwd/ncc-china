using System.ComponentModel.DataAnnotations;
using Ncc.China.Services.Identity.Data;

namespace Ncc.China.Services.Identity.Logic.Dto
{
    public class UserProfileUpdateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string AvatarUrl { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
