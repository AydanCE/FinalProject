using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class AboutImageToAboutDTO : IDto
    {
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public int AboutId { get; set; }
        public string ImageUrl { get; set; }
        public int AboutImageId { get; set; }
    }
}
