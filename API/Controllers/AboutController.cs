using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet("GetAllAbout")]
        public IActionResult GetAll()
        {
            var r = _aboutService.GetAllAbouts();
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }
        [HttpPost("AddAbout")]
        public IActionResult Add(About about)
        {
            var r = _aboutService.AddAbout(about);
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }

    }
}
