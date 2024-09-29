using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [HttpGet("GetFeature")]
        public IActionResult Get(int id)
        {
            var r = _featureService.GetFeature(id);
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }
        [HttpGet("GetAllFeatures")]
        public IActionResult GetAll()
        {
            var r = _featureService.GetAllFeatures();
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }
        [HttpPost("AddFeature")]
        public IActionResult Add(Feature feature)
        {
            var r = _featureService.AddFeature(feature);
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }
    }
}
