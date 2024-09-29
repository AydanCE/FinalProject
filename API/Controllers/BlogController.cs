using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet("GetBlog")]
        public IActionResult Get(int id)
        {
            var r = _blogService.GetBlog(id);
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }
        [HttpGet("GetAllBlogs")]
        public IActionResult GetAll()
        {
            var r = _blogService.GetAllBlogs();
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }
        [HttpPost("AddBlog")]
        public IActionResult Add(Blog blog)
        {
            var r = _blogService.AddBlog(blog);
            if( r.Success )
                return Ok(r);
            return BadRequest(r);
        }
    }
}
