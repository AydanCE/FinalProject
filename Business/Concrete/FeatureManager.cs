using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FeatureManager(IFeatureDal featureDal) : IFeatureService
    {
        private readonly IFeatureDal _featureDal = featureDal;

        public IResult AddFeature(Feature feature)
        {
            _featureDal.Add(feature);
            return new SuccessResult();
        }

        public IResult DeleteFeature(int id)
        {
            Feature deleteFeature = null;
            Feature resultFeature = _featureDal.Get(f => f.IsDeleted == false &&  f.Id == id);
            if (resultFeature != null)
                deleteFeature = resultFeature;
            deleteFeature.IsDeleted = true;
            _featureDal.Delete(deleteFeature);
            return new SuccessResult();
        }

        public IDataResult<List<Feature>> GetAllFeatures()
        {
            var features = _featureDal.GetAll(f => f.IsDeleted == false).ToList();
            if(features.Count != 0)
                return new SuccessDataResult<List<Feature>>(features);
            return new ErrorDataResult<List<Feature>>(features);
        }

        public IDataResult<Feature> GetFeature(int id)
        {
            Feature getFeature = _featureDal.Get(f => f.Id == id && f.IsDeleted == false);
            if(getFeature != null)
                return new SuccessDataResult<Feature>(getFeature);
            return new ErrorDataResult<Feature>(getFeature);
        }

        public IResult UpdateFeature(Feature feature)
        {
            Feature updateFeature = _featureDal.Get(p => p.Id == feature.Id && p.IsDeleted == false);
            updateFeature.Title = feature.Title;
            updateFeature.Description = feature.Description;
            updateFeature.IsFeatured = feature.IsFeatured;
            _featureDal.Update(feature);
            return new SuccessResult();
        }
    }
}
