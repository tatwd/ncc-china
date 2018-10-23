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

        public async Task<Post> GetPost(string id)
        {
            var document = await _context.Posts
                .Find(_ => _.Id.Equals(id))
                .FirstOrDefaultAsync();
            return document;
        }
    }
}
