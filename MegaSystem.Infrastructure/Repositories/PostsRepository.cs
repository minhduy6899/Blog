using MegaSystem.Core.Domain.Entities;
using MegaSystem.Core.Domain.RepositoryContracts;
using MegaSystem.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace MegaSystem.Infrastructure.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly ApplicationDbContext _context;

        public PostsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Post> AddPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> DeletePostById(int id)
        {
           _context.Posts.RemoveRange(_context.Posts.Where(post => post.Id == id));
            int rowsDeleted = await _context.SaveChangesAsync();
            return rowsDeleted > 0;
        }

        public async Task<List<Post>> GetAllPost()
        {
            return await _context.Posts.Include("Blog").ToListAsync();
        }

        public async Task<Post?> GetPostById(int id)
        {
            return await _context.Posts.Include("Blog").FirstOrDefaultAsync(post => post.Id == id);
        }

        public async Task<Post?> UpdatePost(Post post)
        {
            Post? matchingPost = await _context.Posts.FirstOrDefaultAsync(temp => temp.Id == post.Id);
            if (matchingPost == null) 
            {
                return post;
            }
            matchingPost.PostName = post.PostName;  
            matchingPost.BlogId = post.BlogId;
            await _context.SaveChangesAsync();
            return matchingPost;
        }
    }
}
