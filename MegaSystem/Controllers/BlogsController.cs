using MegaSystem.Core;
using MegaSystem.Core.Domain.Entities;
using MegaSystem.Core.DTO;
using MegaSystem.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MegaSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogsService _blogService;

        public BlogsController(IBlogsService blogService)
        {
            _blogService = blogService;
        }

        // GET: api/<BlogsController>
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<BlogResponse>>> Get()
        {
            return Ok(await _blogService.GetAllBlogs());
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {

            var response = await _blogService.GetBlogById(id);
            if (response.IsSuccess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        // POST api/<BlogsController>
        [HttpPost]
        public async Task<IActionResult> AddBlog([FromBody] BlogAddRequest blog)
        {
            var response = await _blogService.AddBlog(blog);
            if (response.IsSuccess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromBody] BlogUpdateRequest blog)
        {
            var response =await _blogService.UpdateBlog(blog);
            if(response.IsSuccess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);    
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBlogById(int id)
        {
            var response = await _blogService.DeleteBlog(id);
            if (response.IsSuccess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
