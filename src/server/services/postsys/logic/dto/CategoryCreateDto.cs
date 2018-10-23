using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Ncc.China.Services.Postsys.Data;

namespace Ncc.China.Services.Postsys.Logic.Dto
{
    public class CategoryCreateDto
    {
        public string Title { get; set; }
    }
}
