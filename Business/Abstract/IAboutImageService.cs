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
    public interface IAboutImageService
    {
        IResult Add(AboutImageDTO aboutImageDTO);
        IDataResult<List<AboutImage>> GetAboutImageById(int aboutId);
        IDataResult<List<AboutImageToAboutDTO>> GetAllAbouts();
    }
}
