using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ProductImageAddDTO : IDto
    {
        public int ProductId {  get; set; }
        public bool IsFeatured { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
