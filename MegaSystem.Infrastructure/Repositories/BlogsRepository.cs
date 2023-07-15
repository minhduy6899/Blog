using MegaSystem.Core.Domain.Entities;
using MegaSystem.Core.Domain.RepositoryContracts;
using MegaSystem.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Infrastructure.Repositories
{
    public class BlogsRepository : IBlogsRepository
    {
        private readonly ApplicationDbContext _context;
        public BlogsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Blog> AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<bool> DeleteBlogById(int id)
        {
            _context.Blogs.RemoveRange(_context.Blogs.Where(temp => temp.Id == id));
            int rowsDeleted = await _context.SaveChangesAsync();
            return rowsDeleted > 0;
        }

        public async Task<List<Blog>> GetAllBlog()
        {
            return await _context.Blogs.Include(blog=> blog.Posts).ToListAsync();
        }

        public async Task<Blog?> GetBlogByBlogName(string blogName)
        {
            return await _context.Blogs.FirstOrDefaultAsync(temp => temp.BlogName == blogName); 
        }

        public async Task<Blog?> GetBlogById(int id)
        {
            return await _context.Blogs.FirstOrDefaultAsync(temp => temp.Id == id);
        }

        public async Task<Blog?> UpdateBlog(Blog blog)
        {
            Blog? matchingBlog = await _context.Blogs.FirstOrDefaultAsync(temp => temp.Id == blog.Id);

            if (matchingBlog == null)
            {
                return blog;
            }
            matchingBlog.BlogName  = blog.BlogName;
            await _context.SaveChangesAsync();

            return matchingBlog;
        }
    }
}
