using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsDiscount {  get; set; }
        public int DiscountRate { get; set; }
        public int CategoryId { get; set; }
        public bool IsFeatured { get; set; }
    }
}
