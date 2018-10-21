using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ncc.China.Services.Postsys.Data
{
    public class Post
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("author")]
        public Owner Author { get; set; }

        [BsonElement("html_text")]
        public string HtmlText { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
