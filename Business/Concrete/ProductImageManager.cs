using Business.Abstract;
using Core.Helpers.Business;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager(IProductImageDal productImageDal, IAddPhotoHelperService addPhotoHelperService) : IProductImageService
    {
        private readonly IProductImageDal _productImageDal = productImageDal;
        private readonly IAddPhotoHelperService _addPhotoHelperService = addPhotoHelperService;
        public IResult Add(ProductImageAddDTO productImageDTO)
        {
            var guid = Guid.NewGuid() + "-" + productImageDTO.ImageUrl.FileName;
            _addPhotoHelperService.AddImage(productImageDTO.ImageUrl, guid);
            ProductImage productImage = new()
            {
                ProductId = productImageDTO.ProductId,
                ImageUrl = "/images/" + guid
            };
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }

        public IDataResult<List<ProductImageToProductDTO>> GetAll()
        {
            var images = _productImageDal.GetAllProductsByFeatured();
            if (images.Count != 0)
            {
                return new SuccessDataResult<List<ProductImageToProductDTO>>(images);
            }
            return new ErrorDataResult<List<ProductImageToProductDTO>>(images);
        }

        public IDataResult<List<ProductImageToProductDTO>> GetAllProducts()
        {
            var images = _productImageDal.GetAllProducts();
            if (images.Count != 0)
            {
                return new SuccessDataResult<List<ProductImageToProductDTO>>(images);
            }
            return new ErrorDataResult<List<ProductImageToProductDTO>>(images);
        }

        public IDataResult<List<ProductImageToProductDTO>> GetAllProductsByCategory(int categoryId)
        {
            var result = _productImageDal.GetAllProductsByCategoryId(categoryId);
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<ProductImageToProductDTO>>(result);
            }
            return new ErrorDataResult<List<ProductImageToProductDTO>>(result);
        }

        public IDataResult<List<ProductImage>> GetProductImageById(int productId)
        {
            var result = _productImageDal.GetAll(i => i.ProductId == productId && i.IsDeleted == false);
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<ProductImage>>(result);
            }
            return new ErrorDataResult<List<ProductImage>>(result);
        }
    }
}
