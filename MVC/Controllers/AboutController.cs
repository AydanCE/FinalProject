using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class AboutController : Controller
    {
        private readonly IFeatureImageService _featureImageService;
        private readonly IAboutImageService _aboutImageService;
        public AboutController(IFeatureImageService featureImageService, IAboutImageService aboutImageService)
        {
            _featureImageService = featureImageService;
            _aboutImageService = aboutImageService;
        }

        public IActionResult Index()
        {
            AboutVM vm = new()
            {
                Features = _featureImageService.GetAll().Data,
                Abouts = _aboutImageService.GetAllAbouts().Data,
            };
            return View(vm);
        }
    }
}
