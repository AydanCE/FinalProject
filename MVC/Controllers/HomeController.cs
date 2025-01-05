using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductImageService _productImageService;
        private readonly IAboutImageService _aboutImageService;
        private readonly IFeatureImageService _featureImageService;
        private readonly IBlogImageService _blogImageService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IProductImageService productImageService, IAboutImageService aboutImageService, IFeatureImageService featureImageService, IBlogImageService blogImageService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _productImageService = productImageService;
            _aboutImageService = aboutImageService;
            _featureImageService = featureImageService;
            _blogImageService = blogImageService;
            _categoryService = categoryService;
        }

        public IActionResult Index(int? categoryId)
        {
            HomeVM vm = new();

            vm.Products = categoryId.HasValue
                ? _productImageService.GetAllFeaturedProductsByCategoryId(categoryId.Value).Data
                : _productImageService.GetAll().Data;
            vm.Abouts = _aboutImageService.GetAllAbouts().Data;
            vm.Features = _featureImageService.GetAll().Data;
            vm.Blogs = _blogImageService.GetAll().Data;
            vm.Categories = _categoryService.GetAllCategories().Data;
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
