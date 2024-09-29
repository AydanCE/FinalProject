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
    public class EfBlogImageDal(BaseProjectContext context) : BaseRepository<BlogImage, BaseProjectContext>(context), IBlogImageDal
    {
        public List<BlogImageToBlogDTO> GetAllBlogs()
        {
            using BaseProjectContext baseContext = new BaseProjectContext();
            var result = from i in baseContext.BlogImages
                         where i.IsDeleted == false
                         join b in baseContext.Blogs
                         on i.BlogId equals b.Id
                         select new BlogImageToBlogDTO
                         {
                             BlogDate = b.Date,
                             BlogDescription = b.Description,
                             BlogId = b.Id,
                             BlogImageId = i.Id,
                             BlogTitle = b.Title,
                             ImageUrl = i.ImageUrl,
                             IsFeatured = i.IsFeatured,
                         };
            return result.ToList();
        }

        public List<BlogImageToBlogDTO> GetAllBlogsByFeatured()
        {
            using BaseProjectContext baseContext = new BaseProjectContext();
            var result = from i in baseContext.BlogImages
                         where i.IsDeleted == false
                         join b in baseContext.Blogs
                         on i.BlogId equals b.Id
                         select new BlogImageToBlogDTO
                         {
                             BlogDate = b.Date,
                             BlogDescription = b.Description,
                             BlogId = b.Id,
                             BlogImageId = i.Id,
                             BlogTitle = b.Title,
                             ImageUrl = i.ImageUrl,
                             IsFeatured = i.IsFeatured,
                         };
            return result.Where(b => b.IsFeatured == true).Take(3).ToList();
        }
    }
}
