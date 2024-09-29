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
    public class FeatureImageManager(IFeatureImageDal featureImageDal, IAddPhotoHelperService addPhotoHelperService) : IFeatureImageService
    {
        private readonly IFeatureImageDal _featureImageDal = featureImageDal;
        private readonly IAddPhotoHelperService _addPhotoHelperService = addPhotoHelperService;

        public IResult Add(FeatureImageDTO featureImageDTO)
        {
            var guid = Guid.NewGuid() + "-" + featureImageDTO.ImageUrl.FileName;
            _addPhotoHelperService.AddImage(featureImageDTO.ImageUrl, guid);
            FeatureImage featureImage = new()
            {
                FeatureId = featureImageDTO.FeatureId,
                ImageUrl = "/images/" +  guid,
            };
            _featureImageDal.Add(featureImage);
            return new SuccessResult();
        }

        public IDataResult<List<FeatureImageToFeatureDTO>> GetAll()
        {
            var images = _featureImageDal.GetAllFeaturesByFeatured();
            if (images.Count != 0)
                return new SuccessDataResult<List<FeatureImageToFeatureDTO>>(images);
            return new ErrorDataResult<List<FeatureImageToFeatureDTO>>(images);
        }

        public IDataResult<List<FeatureImageToFeatureDTO>> GetAllFeatures()
        {
            var images = _featureImageDal.GetAllFeatures();
            if(images.Count != 0)
                return new SuccessDataResult<List<FeatureImageToFeatureDTO>>(images);
            return new ErrorDataResult<List<FeatureImageToFeatureDTO>>(images);
        }

        public IDataResult<List<FeatureImage>> GetFeatureImageById(int featureId)
        {
            var result = _featureImageDal.GetAll(i => i.FeatureId == featureId && i.IsDeleted == false);
            if (result.Count != 0)
                return new SuccessDataResult<List<FeatureImage>>(result);
            return new ErrorDataResult<List<FeatureImage>>(result);

        }
    }
}
