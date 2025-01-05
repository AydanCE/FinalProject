using Business.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class BlogsController : Controller
    {
        private readonly IBlogImageService _blogImageService;
        private readonly IBlogService _blogService;
        public BlogsController(IBlogImageService blogImageService, IBlogService blogService)
        {
            _blogImageService = blogImageService;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogImageDTO blogImageDTO)
        {
            try
            {
                _blogImageService.Add(blogImageDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception )
            {
                return NotFound();
            }
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            try
            {
                blog.Date = DateTime.Now;
                _blogService.AddBlog(blog);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
