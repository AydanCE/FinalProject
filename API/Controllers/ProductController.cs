using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetProduct")]
        public IActionResult Get(int id)
        {
            var r = _productService.GetProduct(id);
            if(r.Success)
            {
                return Ok(r);
            }
            return BadRequest(r);
        }
        [HttpGet("GetAllProducts")]
        public IActionResult GetAll()
        {
            var r = _productService.GetAllProducts();
            if(r.Success)
            {
                return Ok(r);
            }
            return BadRequest(r);
        }
        [HttpPost("AddProduct")]
        public IActionResult Add(Product product)
        {
            var r = _productService.AddProduct(product);
            if(r.Success)
            {
                return Ok(r);
            }
            return BadRequest(r);
        }
    }
}
