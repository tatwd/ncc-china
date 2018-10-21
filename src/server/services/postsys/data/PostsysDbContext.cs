using System;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Ncc.China.Services.Postsys.Data
{
    public class PostsysDbContext
    {
        private readonly IMongoDatabase _context ;

        public PostsysDbContext(string connectionString, string db)
        {
            try
            {
                var client = new MongoClient(connectionString);
                _context = client.GetDatabase(db);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
            get { return _context.GetCollection<Post>($"{nameof(Posts).ToLower()}"); }
        }
    }
}
