using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ncc.China.Services.Postsys.Data;
using Ncc.China.Services.Postsys.Repository;
using Ncc.China.Http.Message;
using Ncc.China.Services.Postsys.Logic.Dto;
using MongoDB.Bson;
using Ncc.China.Http;

namespace Ncc.China.Services.Postsys.Logic
{
    public class PostService
    {
        private IPostRepository _repository;
        private ICategoryRepository _categoryRepository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public PostService(IPostRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        private async Task<PostQueryDto> Map(Post post)
        {
            var category = await _categoryRepository.GetCategory(post.CategoryId);
            return new PostQueryDto(post, category);
        }

        private async Task<IEnumerable<PostQueryDto>> Map(IEnumerable<Post> posts)
        {
            IList<PostQueryDto> data = new List<PostQueryDto>();
            foreach (var post in posts)
            {
                var category = await _categoryRepository.GetCategory(post.CategoryId);
                data.Add(new PostQueryDto(post, category));
            }
            return data;
        }

        public async Task<BaseResponseMessage> GetPosts()
        {
            try
            {
                var posts = await _repository.GetPosts();
                var data = await this.Map(posts);
                return R.Ok.Create(data);
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public async Task<BaseResponseMessage> GetPosts(string id_or_username)
        {
            try
            {
                var posts = await _repository.GetPosts(id_or_username);
                var data = await this.Map(posts);
                return R.Ok.Create(data);
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public async Task<BaseResponseMessage> GetPosts(PostPaginateByCategoryDto dto)
        {
            try
            {
                var posts = await _repository.GetPostsByPage(dto.Page, dto.Limit, dto.Desc, dto.Category);
                var data = await this.Map(posts);
                return R.Ok.Create(data);
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public async Task<BaseResponseMessage> GetPosts(string query, PostPaginateByCategoryDto dto)
        {
            try
            {
                var posts = await _repository.GetPostsByPage(query, dto.Page, dto.Limit, dto.Desc, dto.Category);
                var data = await this.Map(posts);
                return R.Ok.Create(data);
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public async Task<BaseResponseMessage> GetHotPosts()
        {
            try
            {
                var posts = await _repository.GetHotPosts();
                var data = await this.Map(posts);
                return R.Ok.Create(data);
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
                var post = await _repository.GetPost(id);
                if (post == null) return new FailedResponseMessage("不存在该记录");
                var data = await this.Map(post);
                return R.Ok.Create(data);
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public async Task<BaseResponseMessage> DeletePost(string id)
        {
            try
            {
                var post = await _repository.GetPost(id);
                if (post == null) return new FailedResponseMessage("不存在该记录");
                post.IsDeleted = true;
                post.UtcCreated = DateTime.UtcNow;
                var count = _repository.DeletePost(id, post);
                return R.Ok.Create(count);
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public async Task<BaseResponseMessage> CreatePost(PostCreateDto dto)
        {
            try
            {
                var category = await _categoryRepository.GetCategory(dto.CategoryId);
                if (category == null) return new FailedResponseMessage("分类ID无效");
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
                return R.Ok.Create(post.Id);
            }
            catch (Exception ex)
            {
                return R.Ko.Create(ex.Message);
            }
        }
    }
}
