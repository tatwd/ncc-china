using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Ncc.China.Services.Postsys.Data;
using MongoDB.Driver;
using System.Linq;
using MongoDB.Bson;

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

        public async Task<IEnumerable<Post>> GetPosts(string username)
        {
            var documents = await _context.Posts
                .Find(_ => _.Author.Username.Equals(username))
                .ToListAsync();
            return documents;
        }

        public async Task<IEnumerable<Post>> GetHotPosts()
        {
            var documents = await _context.Posts
                .Find(_ => !_.IsDeleted)
                .SortByDescending(_ => _.CommentsCount)
                .Limit(10)
                .ToListAsync();
            return documents;
        }

        public Task<Post> GetPost(string id)
        {
            if(!ObjectId.TryParse(id, out ObjectId _id)) {
                _id = ObjectId.Empty;
            }
            return _context.Posts
                .Find(_ => _.Id == _id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByPage(int page, int limit, bool isDesc, string category)
        {
            var skip = (page - 1) * limit;

            if (category.Equals("全部") || category.Equals("all")) {
                var _posts = _context.Posts.Find(_ => !_.IsDeleted);
                if (isDesc) _posts = _posts.SortByDescending(_ => _.UtcCreated);
                return await _posts
                    .Skip(skip)
                    .Limit(limit)
                    .ToListAsync();
            }

            var categoryId = _context.Categories
                .Find(_ => _.Title.Equals(category.Trim()))
                .FirstOrDefault()
                ?.Id;

            if (!categoryId.HasValue) return Enumerable.Empty<Post>();

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

        public async Task<IEnumerable<Post>> GetPostsByPage(string query, int page, int limit, bool isDesc, string category)
        {
            var skip = (page - 1) * limit;

            if (category.Equals("全部") || category.Equals("all")) {
                return await _context.Posts
                    .Find(_ => !_.IsDeleted && _.Title.Contains(query))
                    .Skip(skip)
                    .Limit(limit)
                    .ToListAsync();
            }

            var categoryId = _context.Categories
                .Find(_ => _.Title.Equals(category.Trim()))
                .FirstOrDefault()
                ?.Id;

            if (!categoryId.HasValue) return Enumerable.Empty<Post>();

            var posts = _context.Posts
                .Find(_ => !_.IsDeleted && _.CategoryId.Equals(categoryId) && _.Title.Contains(query));
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
