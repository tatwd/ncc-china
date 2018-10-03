using System;
using System.ComponentModel.DataAnnotations;

namespace Ncc.China.Services.Identity.Logic.Dto
{
    public class LoginDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
