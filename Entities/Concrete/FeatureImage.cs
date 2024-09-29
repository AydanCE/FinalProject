using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FeatureImage : BaseEntity
    {
        public int FeatureId { get; set; }
        public string ImageUrl { get; set; }
    }
}
