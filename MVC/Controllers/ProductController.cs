using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductImageService _productImageService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductImageService productImageService, ICategoryService categoryService, IProductService productService)
        {
            _productImageService = productImageService;
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index(int? categoryId)
        {
            ProductVM vm = new()
            {
                Products = categoryId.HasValue
                    ? _productImageService.GetAllProductsByCategory(categoryId.Value).Data
                    : _productImageService.GetAllProducts().Data,
                Categories = _categoryService.GetAllCategories().Data,
            };
            return View(vm);
        }
        //public IActionResult Detail(int id)
        //{
        //    ProductVM vm = new()
        //    {
        //        ProductGetById = _productService.GetProduct(id).Data,
        //        ProductImageGetById = _productImageService.GetProductImageById(id).Data,
        //    };
        //    if(vm.ProductGetById != null) return View(vm);
        //    return NotFound();
        //}
    }
}
