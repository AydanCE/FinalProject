using Entities.DTO;

namespace MVC.ViewModels
{
    public class AboutVM
    {
        public List<FeatureImageToFeatureDTO> Features { get; set; }
        public List<AboutImageToAboutDTO> Abouts { get; set; }
    }
}
