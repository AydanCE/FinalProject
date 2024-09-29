using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BlogImage : BaseEntity
    {
        public int BlogId { get; set; }
        public bool IsFeatured { get; set; }
        public string ImageUrl { get; set; }
    }
}
