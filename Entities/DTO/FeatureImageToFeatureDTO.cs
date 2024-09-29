using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class FeatureImageToFeatureDTO : IDto
    {
        public string FeatureTitle { get; set; }
        public string FeatureDescription { get; set; }
        public int FeatureId { get; set; }
        public string ImageUrl { get; set; }
        public int FeatureImageId { get; set; }
        public bool IsFeatured { get; set; }
    }
}
