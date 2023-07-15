using MegaSystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Domain.RepositoryContracts
{
    public interface IPostsRepository
    {
        Task<Post> AddPost(Post post);

        Task<List<Post>> GetAllPost();

        Task<Post?> GetPostById(int id);

        Task<Post?> UpdatePost(Post post);

        Task<bool> DeletePostById(int id);
        
    }
}
