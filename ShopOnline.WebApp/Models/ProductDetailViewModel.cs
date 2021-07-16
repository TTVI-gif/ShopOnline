using ShopOnline.ViewModels.Catalog.Categories;
using ShopOnline.ViewModels.Catalog.ProductImages;
using ShopOnline.ViewModels.Catalog.Products;
using System.Collections.Generic;

namespace ShopOnline.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoriesViewModel Category { get; set; }

        public ProductViewModel Product { get; set; }

        public List<ProductViewModel> RelatedProducts { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
        

    }
}
