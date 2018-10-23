using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ncc.China.Services.Postsys.Data
{
    public class Category
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("utc_created")]
        public DateTime UtcCreated { get; set; } = DateTime.UtcNow;
    }
}
