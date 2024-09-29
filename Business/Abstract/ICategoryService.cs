using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult AddCategory(Category category);
        IResult DeleteCategory(int id);
        IResult UpdateCategory(Category category);
        IDataResult<List<Category>> GetAllCategories();
    }
}
