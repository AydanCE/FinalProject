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
    public interface IBlogImageService
    {
        IResult Add(BlogImageDTO blogImageDTO);
        IDataResult<List<BlogImageToBlogDTO>> GetAll();
        IDataResult<List<BlogImage>> GetBlogImageById(int blogId);
        IDataResult<List<BlogImageToBlogDTO>> GetAllBlogs();
    }
}
