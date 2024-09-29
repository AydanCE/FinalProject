using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeatureService
    {
        IResult AddFeature(Feature feature);
        IResult UpdateFeature(Feature feature);
        IResult DeleteFeature(int id);
        IDataResult<Feature> GetFeature(int id);
        IDataResult<List<Feature>> GetAllFeatures();
    }
}
