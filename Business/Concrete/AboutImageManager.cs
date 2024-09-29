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
    public class AboutImageManager(IAboutImageDal aboutImageDal, IAddPhotoHelperService addPhotoHelperService) : IAboutImageService
    {
        private readonly IAboutImageDal _aboutImageDal = aboutImageDal;
        private readonly IAddPhotoHelperService _addPhotoHelperService = addPhotoHelperService;

        public IResult Add(AboutImageDTO aboutImageDTO)
        {
            var guid = Guid.NewGuid() + "-" + aboutImageDTO.ImageUrl.FileName;
            _addPhotoHelperService.AddImage(aboutImageDTO.ImageUrl, guid);
            AboutImage aboutImage = new()
            {
                AboutId = aboutImageDTO.AboutId,
                ImageUrl = "/images/" + guid,
            };
            _aboutImageDal.Add(aboutImage);
            return new SuccessResult();
        }

        public IDataResult<List<AboutImage>> GetAboutImageById(int aboutId)
        {
            var result = _aboutImageDal.GetAll(i => i.AboutId == aboutId && i.IsDeleted == false);
            if(result.Count != 0)
            {
                return new SuccessDataResult<List<AboutImage>>(result);
            }
            return new ErrorDataResult<List<AboutImage>>(result);
        }

        public IDataResult<List<AboutImageToAboutDTO>> GetAllAbouts()
        {
            var images = _aboutImageDal.GetAllAbouts();
            if(images.Count != 0)
            {
                return new SuccessDataResult<List<AboutImageToAboutDTO>>(images);
            }
            return new ErrorDataResult<List<AboutImageToAboutDTO>>(images);
        }
    }
}
