using ShopOnline.ViewModels.Catalog.Products;
using ShopOnline.ViewModels.Utilities.Slides;
using System.Collections.Generic;

namespace ShopOnline.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideViewModel> Slides { get; set; }
        public List<ProductViewModel> ProductFeature { get; set; }
        public List<ProductViewModel> LatestProduct { get; set; }
    }
}
