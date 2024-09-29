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
    public class EfFeatureImageDal(BaseProjectContext context) : BaseRepository<FeatureImage, BaseProjectContext>(context), IFeatureImageDal
    {
        public List<FeatureImageToFeatureDTO> GetAllFeatures()
        {
            BaseProjectContext baseContext = new BaseProjectContext();
            var result = from i in baseContext.FeatureImages
                         where i.IsDeleted == false
                         join f in baseContext.Features
                         on i.FeatureId equals f.Id
                         select new FeatureImageToFeatureDTO
                         {
                             FeatureDescription = f.Description,
                             FeatureId = f.Id,
                             FeatureImageId = i.Id,
                             FeatureTitle = f.Title,
                             ImageUrl = i.ImageUrl,
                             IsFeatured = f.IsFeatured
                         };
            return result.ToList();
        }

        public List<FeatureImageToFeatureDTO> GetAllFeaturesByFeatured()
        {
            BaseProjectContext baseContext = new BaseProjectContext();
            var result = from i in baseContext.FeatureImages
                         where i.IsDeleted == false
                         join f in baseContext.Features
                         on i.FeatureId equals f.Id
                         select new FeatureImageToFeatureDTO
                         {
                             FeatureDescription = f.Description,
                             FeatureId = f.Id,
                             FeatureImageId = i.Id,
                             FeatureTitle = f.Title,
                             ImageUrl = i.ImageUrl,
                             IsFeatured = f.IsFeatured
                         };
            return result.Where(f => f.IsFeatured == true).Take(3).ToList();
        }
    }
}
