using Microsoft.AspNetCore.Http;
using System;

namespace ShopOnline.ViewModels.Catalog.ProductImages
{
    public class ProductImageCreateRequest
    {

        public string Caption { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
        public int ProductId { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
