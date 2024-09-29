using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult AddBlog(Blog blog);
        IResult DeleteBlog(int id);
        IResult UpdateBlog(Blog blog);
        IDataResult<Blog> GetBlog(int id);
        IDataResult<List<Blog>> GetAllBlogs();
    }
}
