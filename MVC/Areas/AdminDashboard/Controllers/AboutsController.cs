using Business.Abstract;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class AboutsController : Controller
    {
        private readonly IAboutImageService _aboutImageService;
        private readonly IAboutService _aboutService;
        public AboutsController(IAboutImageService aboutImageService, IAboutService aboutService)
        {
            _aboutImageService = aboutImageService;
            _aboutService = aboutService;
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
        public IActionResult Create(AboutImageDTO aboutImageDTO)
        {
            try
            {
                _aboutImageService.Add(aboutImageDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
