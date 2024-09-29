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
    public class AboutManager(IAboutDal aboutDal) : IAboutService
    {
        private readonly IAboutDal _aboutDal = aboutDal;

        public IResult AddAbout(About about)
        {
            _aboutDal.Add(about);
            return new SuccessResult();
        }

        public IResult DeleteAbout(int id)
        {
            About deleteAbout = null;
            About resultAbout = _aboutDal.Get(a => a.IsDeleted == false && a.Id == id);
            if (resultAbout != null)
            {
                deleteAbout = resultAbout;
            }
            deleteAbout.IsDeleted = true;
            _aboutDal.Delete(deleteAbout);
            return new SuccessResult();

        }

        public IDataResult<List<About>> GetAllAbouts()
        {
            var abouts = _aboutDal.GetAll(a => a.IsDeleted == false);
            if(abouts.Count != 0)
            {
                return new SuccessDataResult<List<About>>(abouts);
            }
            return new ErrorDataResult<List<About>>(abouts);
        }
    }
}
