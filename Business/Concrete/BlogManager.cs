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
    public class BlogManager(IBlogDal blogDal) : IBlogService
    {
        private readonly IBlogDal _blogDal = blogDal;

        public IResult AddBlog(Blog blog)
        {
            _blogDal.Add(blog);
            return new SuccessResult();
        }

        public IResult DeleteBlog(int id)
        {
            Blog deleteBlog = null;
            Blog resultBlog = _blogDal.Get(b => b.Id == id && b.IsDeleted == false);
            if (resultBlog != null)
                deleteBlog = resultBlog;
            deleteBlog.IsDeleted = true;
            _blogDal.Delete(resultBlog);
            return new SuccessResult();
        }

        public IDataResult<List<Blog>> GetAllBlogs()
        {
            var blogs = _blogDal.GetAll(b => b.IsDeleted == false).ToList();
            if(blogs.Count != 0)
            {
                return new SuccessDataResult<List<Blog>>(blogs);
            }
            return new ErrorDataResult<List<Blog>>(blogs);
        }

        public IDataResult<Blog> GetBlog(int id)
        {
            Blog getBlog = _blogDal.Get(p => p.Id == id && p.IsDeleted == false);
            if(getBlog != null)
                return new SuccessDataResult<Blog>(getBlog);
            return new ErrorDataResult<Blog>(getBlog);
        }

        public IResult UpdateBlog(Blog blog)
        {
            Blog updateBlog;
            updateBlog = _blogDal.Get(b => b.Id==blog.Id && b.IsDeleted == false);
            updateBlog.Title = blog.Title;
            updateBlog.Description = blog.Description;
            updateBlog.Date = blog.Date;
            updateBlog.IsFeatured = blog.IsFeatured;
            _blogDal.Update(blog);
            return new SuccessResult();
        }
    }
}
