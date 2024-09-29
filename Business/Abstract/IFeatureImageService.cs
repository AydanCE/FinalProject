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
    public interface IFeatureImageService
    {
        IResult Add(FeatureImageDTO featureImageDTO);
        IDataResult<List<FeatureImageToFeatureDTO>> GetAll();
        IDataResult<List<FeatureImage>> GetFeatureImageById(int featureId);
        IDataResult<List<FeatureImageToFeatureDTO>> GetAllFeatures();
    }
}
