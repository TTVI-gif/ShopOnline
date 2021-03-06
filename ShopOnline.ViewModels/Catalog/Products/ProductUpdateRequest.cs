using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.ViewModels.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int ID { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }
        public bool? Isfeatured { get; set; }
        public string LanguageId { set; get; }
        public IFormFile ThumbaiImage { get; set; }
    }
}
