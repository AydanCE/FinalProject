using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EfProductImageDal(BaseProjectContext context) : BaseRepository<ProductImage, BaseProjectContext>(context), IProductImageDal
    {
        public List<ProductImageToProductDTO> GetAllProducts()
        {
            BaseProjectContext baseContext = new BaseProjectContext();
            var result = from i in baseContext.ProductImages
                         where i.IsDeleted == false
                         join p in baseContext.Products
                         on i.ProductId equals p.Id
                         select new ProductImageToProductDTO
                         {
                             ProductId = i.ProductId,
                             IsFeaturated = p.IsFeatured,
                             ImageUrl = i.ImageUrl,
                             ProductName = p.ProductName,
                             ProductPrice = p.Price,
                         };
            return result.ToList();
        }

        public List<ProductImageToProductDTO> GetAllProductsByFeatured()
        {
            BaseProjectContext baseContext = new BaseProjectContext();
            var result = from i in baseContext.ProductImages
                         where i.IsDeleted == false
                         join p in baseContext.Products
                         on i.ProductId equals p.Id
                         select new ProductImageToProductDTO
                         {
                             ProductId = i.ProductId,
                             IsFeaturated = p.IsFeatured,
                             ImageUrl = i.ImageUrl,
                             ProductName = p.ProductName,
                             ProductPrice = p.Price,
                         };
            return result.Where(p => p.IsFeaturated == true).Take(3).ToList();
        }
        public List<ProductImageToProductDTO> GetAllProductsByCategoryId(int categoryId)
        {
            BaseProjectContext baseContext = new BaseProjectContext();
            var result = from p in baseContext.Products
                         where p.IsDeleted == false && p.CategoryId == categoryId
                         join pi in baseContext.ProductImages
                         on p.Id equals pi.ProductId
                         select new ProductImageToProductDTO
                         {
                             ProductId = p.Id,
                             ProductName = p.ProductName,
                             ProductPrice = p.Price,
                             IsFeaturated = p.IsFeatured,
                             ImageUrl = pi.ImageUrl,
                             ProductImageId = pi.Id
                         };
            return result.ToList();

        }
    }
}
