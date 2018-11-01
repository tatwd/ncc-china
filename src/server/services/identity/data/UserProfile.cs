using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ncc.China.Services.Identity.Data
{
    [Table("user_profile")]
    public class UserProfile
    {
        [Column("id"), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("user_id", TypeName = "char(32)"), Required]
        public string UserId { get; set; }

        [Column("nickname", TypeName = "varchar(100)")]
        public string Nickname { get; set; }

        [Column("bio", TypeName = "varchar(200)")]
        public string Bio { get; set; }

        [Column("gender", TypeName = "tinyint(3)")]
        public Gender Gender { get; set; } = Gender.Unknown;

        [Column("avatar_url", TypeName = "text")]
        public string AvatarUrl { get; set; }

        [Column("utc_created", TypeName = "datetime"), Required]
        public DateTime UtcCreated { get; set; } = DateTime.UtcNow;

        [Column("utc_updated", TypeName = "datetime "), Required]
        public DateTime UtcUpdated { get; set; } = DateTime.UtcNow;
    }

    public enum Gender : byte
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
    }
}
