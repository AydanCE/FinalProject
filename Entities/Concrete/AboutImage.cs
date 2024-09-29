using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AboutImage : BaseEntity
    {
        public int AboutId { get; set; }
        public string ImageUrl { get; set; }
    }
}
