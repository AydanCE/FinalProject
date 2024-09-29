using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EfAboutImageDal(BaseProjectContext context) : BaseRepository<AboutImage, BaseProjectContext>(context), IAboutImageDal
    {
        public List<AboutImageToAboutDTO> GetAllAbouts()
        {
            BaseProjectContext baseContext = new BaseProjectContext();
            var result = from i in baseContext.AboutImages
                         where i.IsDeleted == false
                         join a in baseContext.Abouts
                         on i.AboutId equals a.Id
                         select new AboutImageToAboutDTO
                         {
                             AboutDescription = a.Description,
                             AboutId = a.Id,
                             AboutImageId = i.Id,
                             AboutTitle = a.Title,
                             ImageUrl = i.ImageUrl
                         };
            return result.ToList();
        }
    }
}
