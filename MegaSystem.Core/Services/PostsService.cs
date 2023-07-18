using AutoMapper;
using MegaSystem.Core.Domain.Entities;
using MegaSystem.Core.Domain.RepositoryContracts;
using MegaSystem.Core.DTO;
using MegaSystem.Core.Helpers;
using MegaSystem.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Services
{
    public class PostsService : IPostsService
    {

        private readonly IPostsRepository _postsRepository;
        private readonly IMapper _mapper;
        public PostsService(IPostsRepository postsRepository, IMapper mapper)
        {
            _postsRepository=postsRepository;
            _mapper=mapper;
        }

        public async Task<ServiceResponse<PostResponse>> AddPost(PostAddRequest postAddRequest)
        {
            var serviceResponse = new ServiceResponse<PostResponse>();
            // param postAddRequest not null
            if (postAddRequest == null) throw new ArgumentNullException(nameof(postAddRequest));

            //Model Validation
            ValidationHelper.ModelValidation(postAddRequest);

            // validate Name not null
            if (postAddRequest.PostName == null)
            {
                throw new ArgumentException("Post name can't be blank");
            }

            //convert Type PostAddRequest to Post
            Post post = _mapper.Map<Post>(postAddRequest);

            //Add post to database
            await _postsRepository.AddPost(post);

            // save to ServiceResponse
            serviceResponse.Data = _mapper.Map<PostResponse>(post);
            serviceResponse.IsSuccess = true;
            return serviceResponse;

        }

        public async Task<ServiceResponse<PostResponse>> DeletePost(int? id)
        {
            var serviceResponse = new ServiceResponse<PostResponse>();
            if (id == 0)
            {
                serviceResponse.Message = $"Post with Id '{id}' invalid";
                return serviceResponse;
            };
            Post? post = await _postsRepository.GetPostById(id.Value);
            if (post == null)
            {
                serviceResponse.Message = $"Post with Id '{id}' not found";
                return serviceResponse;
            };

            await _postsRepository.DeletePostById(post.Id);
            serviceResponse.IsSuccess = true;
            serviceResponse.Message =  $"Post with Id '{id}' deleted";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PostResponse>>> GetAllPosts()
        {
            List<Post> posts = await _postsRepository.GetAllPost();
            var serviceResponse = new ServiceResponse<List<PostResponse>>();

            serviceResponse.Data = posts.Select(temp =>
            {
                var post = _mapper.Map<PostResponse>(temp);
                
                return post;
            }).ToList();
            serviceResponse.IsSuccess = true;
            return serviceResponse;
        }

        public async Task<ServiceResponse<PostResponse>> GetPostById(int? id)
        {
            var serviceResponse = new ServiceResponse<PostResponse>();
            if (id == 0)
            {
                serviceResponse.Message = $"Blog with Id '{id}' invalid";
                return serviceResponse;
            };
            Post? blog = await _postsRepository.GetPostById(id.Value);
            if (blog == null)
            {
                serviceResponse.Message = $"Blog with Id '{id}' not found";
                return serviceResponse;
            };

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = _mapper.Map<PostResponse>(blog);
           
            return serviceResponse;
        }

        public async Task<ServiceResponse<PostResponse>> UpdatePost(PostUpdateRequest postUpdateRequest)
        {
            var serviceResponse = new ServiceResponse<PostResponse>();
            if (postUpdateRequest == null)
            {
                serviceResponse.Message = new ArgumentNullException(nameof(postUpdateRequest)).Message;
                return serviceResponse;
            }
            if (postUpdateRequest.PostName == null)
            {
                serviceResponse.Message = new ArgumentException(nameof(postUpdateRequest.PostName)).Message;
                return serviceResponse;
            }
            if (await _postsRepository.GetPostById(postUpdateRequest.Id) == null)
            {
                serviceResponse.Message = $"Blog with Id '{postUpdateRequest.Id}' not found.";
                return serviceResponse;
            }
            Post? post = await _postsRepository.UpdatePost(_mapper.Map<Post>(postUpdateRequest));
            serviceResponse.Data = _mapper.Map<PostResponse>(post);
            serviceResponse.IsSuccess = true;
            return serviceResponse;
        }
    }
}
