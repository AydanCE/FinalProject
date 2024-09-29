using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class AboutImageDTO : IDto
    {
        public int AboutId { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
