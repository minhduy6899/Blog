using MegaSystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Domain.RepositoryContracts
{
    public interface IBlogsRepository
    {
        Task<Blog> AddBlog(Blog blog);

        Task<List<Blog>> GetAllBlog();

        Task<Blog?> GetBlogById(int id);

        Task<Blog?> UpdateBlog(Blog blog);

        Task<bool> DeleteBlogById(int id);

        Task<Blog?> GetBlogByBlogName(string blogName);
    }
}
