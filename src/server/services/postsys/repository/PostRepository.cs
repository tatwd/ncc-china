using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Ncc.China.Services.Postsys.Data;
using MongoDB.Driver;

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

        public void CreatePost(Post post)
        {
            _context.Posts.InsertOne(post);
        }
    }
}
