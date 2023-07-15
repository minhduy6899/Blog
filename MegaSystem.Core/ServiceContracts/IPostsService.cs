using MegaSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.ServiceContracts
{
    public interface IPostsService
    {
        Task<ServiceResponse<PostResponse>> AddPost(PostAddRequest postAddRequest);

        Task<ServiceResponse<List<PostResponse>>> GetAllPosts();

        Task<ServiceResponse<PostResponse>> GetPostById(int? id);

        Task<ServiceResponse<PostResponse>> UpdatePost(PostUpdateRequest postUpdateRequest);

        Task<ServiceResponse<PostResponse>> DeletePost(int? id);
    }
}
