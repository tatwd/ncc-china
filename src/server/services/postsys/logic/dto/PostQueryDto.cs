using System;
using MongoDB.Bson;
using Ncc.China.Services.Postsys.Data;

namespace Ncc.China.Services.Postsys.Logic.Dto
{
    public class PostQueryDto
    {
        public ObjectId Id { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public Owner Author { get; set; }
        public string AbstractText { get; set; }
        public string HtmlText { get; set; }
        public int ViewsCount { get; set; }
        public int CommentsCount { get; set; }
        public string[] Tags { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }

        public PostQueryDto(Post post, Category category)
        {
            this.Id = post.Id;
            this.Category = category;
            this.Title = post.Title;
            this.Author = post.Author;
            this.AbstractText = post.AbstractText;
            this.HtmlText = post.HtmlText;
            this.ViewsCount = post.ViewsCount;
            this.CommentsCount = post.CommentsCount;
            this.Tags = post.Tags;
            this.IsDeleted = post.IsDeleted;
            this.UtcCreated = post.UtcCreated;
            this.UtcUpdated = post.UtcUpdated;
        }
    }
}
