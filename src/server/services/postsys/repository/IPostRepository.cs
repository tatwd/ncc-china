using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ncc.China.Services.Postsys.Data;

namespace Ncc.China.Services.Postsys.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(string id);
        void CreatePost(Post post);

    }
}
