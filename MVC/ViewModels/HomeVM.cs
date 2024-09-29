using Entities.Concrete;
using Entities.DTO;

namespace MVC.ViewModels
{
    public class HomeVM
    {
        public List<ProductImageToProductDTO> Products { get; set; }
        public List<FeatureImageToFeatureDTO> Features { get; set; }
        public List<BlogImageToBlogDTO> Blogs { get; set; }
        public List<AboutImageToAboutDTO> Abouts { get; set; }
        public List<Category> Categories { get; set; }
    }
}
