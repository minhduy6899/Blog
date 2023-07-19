using AutoMapper;
using MegaSystem.Core.Domain.Entities;
using MegaSystem.Core.Domain.RepositoryContracts;
using MegaSystem.Core.DTO;
using MegaSystem.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Services
{
    public class BlogsService : IBlogsService
    {
        private readonly IBlogsRepository _blogsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public BlogsService(IBlogsRepository blogsRepository, IMapper mapper, IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _blogsRepository = blogsRepository;
            _mapper = mapper;
        }

        // Add
        public async Task<ServiceResponse<BlogResponse>> AddBlog(BlogAddRequest? blogAddRequest)
        {

            var serviceResponse = new ServiceResponse<BlogResponse>();
            if (blogAddRequest == null)
            {
                serviceResponse.Message = new ArgumentNullException(nameof(blogAddRequest)).Message;
                return serviceResponse;
            } 
            if (blogAddRequest.BlogName == null)
            {
                serviceResponse.Message = new ArgumentException(nameof(blogAddRequest.BlogName)).Message;
                return serviceResponse;
            }
            if (await _blogsRepository.GetBlogByBlogName(blogAddRequest.BlogName) != null)
            {
                serviceResponse.Message = new ArgumentException("Given blog name already exists").Message;
                return serviceResponse;
            }
            Blog blog = _mapper.Map<Blog>(blogAddRequest);

            await _blogsRepository.AddBlog(blog);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = await _mapper.Map<BlogResponse>(blog).ToBlogResponseBlogger( _usersRepository);
            
            return serviceResponse;
        }

        

        // Get all
        public async Task<ServiceResponse<List<BlogResponse>>> GetAllBlogs()
        {
            List<Blog> blogs = await _blogsRepository.GetAllBlog();
            var serviceResponse = new ServiceResponse<List<BlogResponse>>();
            serviceResponse.Data = new List<BlogResponse>();
            foreach (var blog in blogs)
            {
                BlogResponse blogResponse = _mapper.Map<BlogResponse>(blog);
                await blogResponse.ToBlogResponseBlogger(_usersRepository);
                serviceResponse.Data.Add(blogResponse);
            }
            serviceResponse.IsSuccess = true;
            return serviceResponse;
        }
        // Get by id
        public async Task<ServiceResponse<BlogResponse>> GetBlogById(int? id)
        {
            var serviceResponse = new ServiceResponse<BlogResponse>();
            if (id == 0)
            {
                serviceResponse.Message = $"Blog with Id '{id}' invalid";
                return serviceResponse;
            };
            Blog? blog = await _blogsRepository.GetBlogById(id.Value);
            if (blog == null)
            {
                serviceResponse.Message = $"Blog with Id '{id}' not found";
                return serviceResponse;
            };
          
            serviceResponse.IsSuccess = true;
            serviceResponse.Data = await _mapper.Map<BlogResponse>(blog).ToBlogResponseBlogger(_usersRepository);
            return serviceResponse;
        }

        // Update
        public async Task<ServiceResponse<BlogResponse>> UpdateBlog(BlogUpdateRequest? blogUpdateRequest)
        {
            var serviceResponse = new ServiceResponse<BlogResponse>();
            if (blogUpdateRequest == null)
            {
                serviceResponse.Message = new ArgumentNullException(nameof(blogUpdateRequest)).Message;
                return serviceResponse;
            }
            if (blogUpdateRequest.BlogName == null)
            {
                serviceResponse.Message = new ArgumentException(nameof(blogUpdateRequest.BlogName)).Message;
                return serviceResponse;
            }
            if (await _usersRepository.GetUserById(blogUpdateRequest.UserId) == null)
            {
                serviceResponse.Message = $"Blogger with Id '{blogUpdateRequest.Id}' not found.";
                return serviceResponse;
            }
            if (await _blogsRepository.GetBlogById(blogUpdateRequest.Id) == null)
            {
                serviceResponse.Message = $"Blog with Id '{blogUpdateRequest.Id}' not found.";
                return serviceResponse;
            }
            
            serviceResponse.Data = await _mapper.Map<BlogResponse>
                (await _blogsRepository.UpdateBlog(_mapper.Map<Blog>(blogUpdateRequest))).ToBlogResponseBlogger(_usersRepository);
            serviceResponse.IsSuccess = true;
            return serviceResponse;
        }

        //delete
        public async Task<ServiceResponse<BlogResponse>> DeleteBlog(int? id)
        {
            var serviceResponse = new ServiceResponse<BlogResponse>();
            if (id == 0)
            {
                serviceResponse.Message = $"Blog with Id '{id}' invalid";
                return serviceResponse;
            };
            Blog? blog = await _blogsRepository.GetBlogById(id.Value);
            if (blog == null)
            {
                serviceResponse.Message = $"Blog with Id '{id}' not found";
                return serviceResponse;
            }; 
            await _blogsRepository.DeleteBlogById(blog.Id);
            serviceResponse.IsSuccess = true;
            serviceResponse.Message =  $"Blog with Id '{id}' deleted";
            return serviceResponse;

        }

       
    }
}
