using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ncc.China.Services.Postsys.Data;
using Ncc.China.Services.Postsys.Repository;
using Ncc.China.Http.Message;
using Ncc.China.Services.Postsys.Logic.Dto;

namespace Ncc.China.Services.Postsys.Logic
{
    public class CategoryService
    {
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public BaseResponseMessage CreateCategory(CategoryCreateDto dto)
        {
            try
            {
                var category = new Category
                {
                    Title = dto.Title
                };
                _repository.CreateCategory(category);
                return new SucceededResponseMessage(category.Id.ToString());
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }

        public async Task<BaseResponseMessage> GetCategorys()
        {
            try
            {
                var categories = await _repository.GetCategories();
                return new SucceededResponseMessage(categories);
            }
            catch (Exception ex)
            {
                return new FailedResponseMessage(ex.Message);
            }
        }
    }
}
