using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ncc.China.Services.Postsys.Data;
using Ncc.China.Services.Postsys.Repository;
using Ncc.China.Http.Message;
using Ncc.China.Services.Postsys.Logic.Dto;
using MongoDB.Bson;

namespace Ncc.China.Services.Postsys.Logic
{
    public class PostService
    {
        private IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponseMessage> GetPosts()
        {
            try
            {
                var data = (await _repository.GetPosts()).ToList();
                return new SucceededResponseMessage(data);
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public async Task<BaseResponseMessage> GetPost(string id)
        {
            try
            {
                var data = await _repository.GetPost(id);
                if (data == null) return new FailedResponseMessage("不存在该记录");
                return new SucceededResponseMessage(data);
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public BaseResponseMessage CreatePost(PostCreateDto dto)
        {
            try
            {
                var post = new Post
                {
                    Title = dto.Title,
                    AbstractText = dto.AbstractText,
                    HtmlText = dto.HtmlText,
                    CategoryId = ObjectId.Parse(dto.CategoryId),
                    Author = dto.Author,
                    Tags = dto.Tags
                };
                _repository.CreatePost(post);
                return new SucceededResponseMessage(post.Id);
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }
    }
}
