using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureImageService _featureImageService;
        public FeatureController(IFeatureImageService featureImageService)
        {
            _featureImageService = featureImageService;
        }

        public IActionResult Index()
        {
            FeatureVM vm = new()
            {
                Features = _featureImageService.GetAllFeatures().Data,
            };
            return View(vm);
        }
    }
}
