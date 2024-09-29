using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ProductImageToProductDTO : IDto
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public bool IsDiscount {  get; set; }
        public int DiscountRate { get; set; }
        public int ProductId { get; set; }
        public bool IsFeaturated { get; set; }
        public string ImageUrl { get; set; }
        public int ProductImageId { get; set; }
    }
}
