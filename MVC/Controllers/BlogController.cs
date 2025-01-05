using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogImageService _blogImageService;
        public BlogController(IBlogImageService blogImageService)
        {
            _blogImageService = blogImageService;
        }

        public IActionResult Index()
        {
            BlogVM vm = new()
            {
                Blogs = _blogImageService.GetAllBlogs().Data,
            };
            return View(vm);
        }
    }
}
