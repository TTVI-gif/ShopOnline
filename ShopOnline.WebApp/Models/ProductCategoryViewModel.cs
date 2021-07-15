using ShopOnline.ViewModels.Catalog.Categories;
using ShopOnline.ViewModels.Catalog.Products;
using ShopOnline.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoriesViewModel Category { get; set; }
        public PagedResult<ProductViewModel> Products { get; set; }
    }
}
