using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ncc.China.Services.Postsys.Data
{
    public class Owner
    {
        // this is not mongo db id
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("avatar_url")]
        public string AvatarUrl { get; set; }

        [BsonElement("is_admin")]
        public bool IsAdmin { get; set; } = false;

        // [BsonElement("is_deleted")]
        // public bool IsDeleted { get; set; }
    }
}
