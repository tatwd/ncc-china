using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Ncc.China.Services.Postsys.Data;
using MongoDB.Driver;
using System.Linq;

namespace Ncc.China.Services.Postsys.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly PostsysDbContext _context = null;

        public PostRepository(IOptions<MongoSettings> settings)
        {
            _context = new PostsysDbContext(settings);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var documents = await _context.Posts.Find(_ => true).ToListAsync();
            return documents;
        }

        public Task<Post> GetPost(string id)
        {
            return _context.Posts
                .Find(_ => _.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByPage(int page, int limit, bool isDesc, string category)
        {
            var categoryId = _context.Categories
                .Find(_ => _.Title.Equals(category.Trim()))
                .FirstOrDefault()
                ?.Id;

            if (!categoryId.HasValue) return Enumerable.Empty<Post>();

            var skip = (page - 1) * limit;
            var posts = _context.Posts
                .Find(_ => !_.IsDeleted && _.CategoryId.Equals(categoryId));
            posts = !isDesc
                ? posts.SortBy(_ => _.UtcCreated)
                : posts.SortByDescending(_ => _.UtcCreated);

            return await posts
                .Skip(skip)
                .Limit(limit)
                .ToListAsync();
        }

        public void CreatePost(Post post)
        {
            _context.Posts.InsertOne(post);
        }
    }
}
