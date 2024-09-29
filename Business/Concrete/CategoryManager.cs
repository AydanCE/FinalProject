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
    public class CategoryManager(ICategoryDal categoryDal) : ICategoryService
    {
        private readonly ICategoryDal _categoryDal = categoryDal;

        public IResult AddCategory(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult DeleteCategory(int id)
        {
            Category deleteCategory = null;
            Category resultCategory = _categoryDal.Get(c => c.IsDeleted == false &&  c.Id == id);
            if (resultCategory != null)
            {
                deleteCategory = resultCategory;
            }
            deleteCategory.IsDeleted = true;
            _categoryDal.Delete(deleteCategory);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAllCategories()
        {
            var categories = _categoryDal.GetAll(c => c.IsDeleted == false).ToList();
            if(categories.Count != 0)
                return new SuccessDataResult<List<Category>>(categories);
            return new ErrorDataResult<List<Category>>(categories);
        }

        public IResult UpdateCategory(Category category)
        {
            Category updateCategory;
            updateCategory = _categoryDal.Get(c => c.Id == category.Id && c.IsDeleted == false);
            updateCategory.CategoryName = category.CategoryName;
            _categoryDal.Update(category);
            return new SuccessResult();
        }
    }
}
