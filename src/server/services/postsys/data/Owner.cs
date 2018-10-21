using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ncc.China.Services.Postsys.Data
{
    public class Owner
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
