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
    public class BlogImageManager(IBlogImageDal blogImageDal, IAddPhotoHelperService addPhotoHelperService) : IBlogImageService
    {
        private readonly IBlogImageDal _blogImageDal = blogImageDal;
        private readonly IAddPhotoHelperService _addPhotoHelperService = addPhotoHelperService;

        public IResult Add(BlogImageDTO blogImageDTO)
        {
            var guid = Guid.NewGuid() + "-" + blogImageDTO.ImageUrl.FileName;
            _addPhotoHelperService.AddImage(blogImageDTO.ImageUrl, guid);
            BlogImage blogImage = new()
            {
                BlogId = blogImageDTO.BlogId,
                ImageUrl = "/images/" + guid,
            };
            _blogImageDal.Add(blogImage);
            return new SuccessResult();
        }

        public IDataResult<List<BlogImageToBlogDTO>> GetAll()
        {
            var images = _blogImageDal.GetAllBlogsByFeatured();
            if(images.Count != 0)
            {
                return new SuccessDataResult<List<BlogImageToBlogDTO>>(images);
            }
            return new ErrorDataResult<List<BlogImageToBlogDTO>>(images);
        }

        public IDataResult<List<BlogImageToBlogDTO>> GetAllBlogs()
        {
            var images = _blogImageDal.GetAllBlogs();
            if(images.Count != 0)
            {
                return new SuccessDataResult<List<BlogImageToBlogDTO>>(images);
            }
            return new ErrorDataResult<List<BlogImageToBlogDTO>>(images);
        }

        public IDataResult<List<BlogImage>> GetBlogImageById(int blogId)
        {
            var result = _blogImageDal.GetAll(i => i.BlogId == blogId && i.IsDeleted == false);
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<BlogImage>>(result);
            }
            return new ErrorDataResult<List<BlogImage>>(result);
        }

    }
}
