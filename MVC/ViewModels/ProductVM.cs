using Entities.Concrete;
using Entities.DTO;

namespace MVC.ViewModels
{
    public class ProductVM
    {
        public List<ProductImageToProductDTO> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
