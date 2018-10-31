using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Ncc.China.Services.Postsys.Data;

namespace Ncc.China.Services.Postsys.Repository
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category category);
        Task<Category> GetCategory(string id);
        Task<Category> GetCategory(ObjectId id);
        Task<IEnumerable<Category>> GetCategories();
        IEnumerable<Category> GetCategories(IEnumerable<ObjectId> ids);
    }
}
