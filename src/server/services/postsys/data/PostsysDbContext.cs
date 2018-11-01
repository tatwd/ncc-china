using System;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Ncc.China.Services.Postsys.Data
{
    public class PostsysDbContext
    {
        private readonly IMongoDatabase _context ;

        public PostsysDbContext(IOptions<MongoSettings> options)
        {
            try
            {
                var client = new MongoClient(options.Value.ConnectionString);
                _context = client.GetDatabase(options.Value.DatabaseName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IMongoCollection<Post> Posts
        {
            get { return _context.GetCollection<Post>("posts"); }
        }

        public IMongoCollection<Category> Categories
        {
            get { return _context.GetCollection<Category>("categories"); }
        }
    }
}
