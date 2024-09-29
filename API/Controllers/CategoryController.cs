using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetAllCategories")]
        public IActionResult GetAll()
        {
            var r = _categoryService.GetAllCategories();
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }
        [HttpPost("AddCategory")]
        public IActionResult Add(Category category)
        {
            var r = _categoryService.AddCategory(category);
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }
    }
}
