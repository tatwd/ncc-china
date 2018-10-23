using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ncc.China.Services.Postsys.Data
{
    public class Post
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("category_id")]
        public ObjectId CategoryId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("author")]
        public Owner Author { get; set; }

        [BsonElement("abstract_text")]
        public string AbstractText { get; set; } = string.Empty;

        [BsonElement("html_text")]
        public string HtmlText { get; set; }

        [BsonElement("views_count")]
        public int ViewsCount { get; set; } = 0;

        [BsonElement("comments_count")]
        public int CommentsCount { get; set; } = 0;

        [BsonElement("tags")]
        public string[] Tags { get; set; }

        [BsonElement("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [BsonElement("utc_created")]
        public DateTime UtcCreated { get; set; } = DateTime.UtcNow;

        [BsonElement("utc_updated")]
        public DateTime UtcUpdated { get; set; } = DateTime.UtcNow;
    }
}
