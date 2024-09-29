using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class BlogImageToBlogDTO : IDto
    {
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public int BlogId { get; set; }
        public DateTime BlogDate { get; set; }
        public string ImageUrl { get; set; }
        public int BlogImageId { get; set; }
        public bool IsFeatured { get; set; }
    }
}
