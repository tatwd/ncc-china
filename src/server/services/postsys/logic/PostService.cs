using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ncc.China.Services.Postsys.Data;
using Ncc.China.Services.Postsys.Repository;
using Ncc.China.Http.Message;

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
    }
}
