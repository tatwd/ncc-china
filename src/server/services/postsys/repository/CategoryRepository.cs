using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Ncc.China.Services.Postsys.Data;
using MongoDB.Driver;

namespace Ncc.China.Services.Postsys.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PostsysDbContext _context = null;

        public CategoryRepository(IOptions<MongoSettings> settings)
        {
            _context = new PostsysDbContext(settings);
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.InsertOne(category);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var documents = await _context.Categories.Find(_ => true).ToListAsync();
            return documents;
        }

        public Task<Category> GetCategory(string id)
        {
            return _context.Categories
                .Find(_ => _.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
    }
}
