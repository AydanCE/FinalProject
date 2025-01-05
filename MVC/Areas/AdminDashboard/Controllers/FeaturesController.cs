using Business.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class FeaturesController : Controller
    {
        private readonly IFeatureImageService _featureImageService;
        private readonly IFeatureService _featureService;
        public FeaturesController(IFeatureImageService featureImageService, IFeatureService featureService)
        {
            _featureImageService = featureImageService;
            _featureService = featureService;
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
        public IActionResult Create(FeatureImageDTO featureImageDTO)
        {
            try
            {
                _featureImageService.Add(featureImageDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Feature feature)
        {
            try
            {
                _featureService.AddFeature(feature);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
