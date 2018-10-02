using System.ComponentModel.DataAnnotations;

namespace Ncc.China.Services.Identity.Loigc.Dto
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(18)]
        public string Password { get; set; }
    }
}
