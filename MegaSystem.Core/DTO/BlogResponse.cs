using AutoMapper;
using MegaSystem.Core.Domain.Entities;
using MegaSystem.Core.Domain.RepositoryContracts;


namespace MegaSystem.Core.DTO
{
    public class BlogResponse
    {
        public int Id { get; set; }

        public string? BlogName { get; set; }

        public int UserId { get; set; }

        public string? Blogger { get; set; }
    }
    public static class BlogExtensions
    {
        public static async Task<BlogResponse> ToBlogResponseBlogger(this BlogResponse blog, IUsersRepository _usersRepository)
        {
            User? user = await _usersRepository.GetUserById(blog.UserId);
            blog.Blogger = user?.UserName;
            return blog;
        }

    }
}
