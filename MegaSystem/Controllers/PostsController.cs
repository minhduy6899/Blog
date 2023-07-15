using MegaSystem.Core.DTO;
using MegaSystem.Core;
using MegaSystem.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using MegaSystem.Core.Services;
using MegaSystem.Core.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MegaSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService=postsService;
        }



        // GET: api/<PostsController>
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<PostResponse>>> Get()
        {
            return Ok(await _postsService.GetAllPosts());
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {

            var response = await _postsService.GetPostById(id);
            if (response.IsSuccess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        // POST api/<PostsController>
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostAddRequest postAddRequest)
        {
            var response = await _postsService.AddPost(postAddRequest);
            if (response.IsSuccess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromBody] PostUpdateRequest blog)
        {
            var response = await _postsService.UpdatePost(blog);
            if (response.IsSuccess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePostById(int id)
        {
            var response = await _postsService.DeletePost(id);
            if (response.IsSuccess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
