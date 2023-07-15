using MegaSystem.Core.DTO;

namespace MegaSystem.Core.ServiceContracts
{
    public interface IBlogsService
    {
        Task<ServiceResponse<BlogResponse>> AddBlog(BlogAddRequest blogAddRequest);

        Task<ServiceResponse<List<BlogResponse>>> GetAllBlogs();

        Task<ServiceResponse<BlogResponse>> GetBlogById(int? id);

        Task<ServiceResponse<BlogResponse>> UpdateBlog(BlogUpdateRequest blogUpdateRequest);

        Task<ServiceResponse<BlogResponse>> DeleteBlog(int? id);

  
    }
}