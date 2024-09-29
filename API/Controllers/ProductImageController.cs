using Business.Abstract;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(ProductImageAddDTO productImageAddDTO)
        {
            var result = _productImageService.Add(productImageAddDTO);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var result = _productImageService.GetAll();
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{productId}")]
        public IActionResult GetProductImagesById(int productId)
        {
            var result = _productImageService.GetProductImageById(productId);
            if(result.Success )
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("all-products")]
        public IActionResult GetAllProducts()
        {
            var result = _productImageService.GetAllProducts();
            if(result.Success )
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var result = _productImageService.GetAllProductsByCategory(categoryId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
