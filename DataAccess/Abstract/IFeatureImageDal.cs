using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFeatureImageDal : IBaseRepository<FeatureImage>
    {
        List<FeatureImageToFeatureDTO> GetAllFeatures();
        List<FeatureImageToFeatureDTO> GetAllFeaturesByFeatured();
    }
}
