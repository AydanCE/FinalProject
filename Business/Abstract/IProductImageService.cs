using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(ProductImageAddDTO productImageDTO);
        IDataResult<List<ProductImageToProductDTO>> GetAll();
        IDataResult<List<ProductImage>> GetProductImageById(int productId);
        IDataResult<List<ProductImageToProductDTO>> GetAllProducts();
        IDataResult<List<ProductImageToProductDTO>> GetAllProductsByCategory(int categoryId);
        IDataResult<List<ProductImageToProductDTO>> GetAllFeaturedProductsByCategoryId(int categoryId);
    }
}
