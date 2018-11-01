using System.ComponentModel.DataAnnotations;

namespace Ncc.China.Services.Identity.Logic.Dto
{
    public class PasswordUpdateDto
    {
        [Required]
        public string Old { get; set; }

        [Required]
        public string New { get; set; }
    }
}
