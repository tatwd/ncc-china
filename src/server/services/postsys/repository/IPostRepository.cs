﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ncc.China.Services.Postsys.Data;

namespace Ncc.China.Services.Postsys.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(string id);
        Task<IEnumerable<Post>> GetPostsByPage(int page, int limit, bool isDesc, string category);
        void CreatePost(Post post);

    }
}