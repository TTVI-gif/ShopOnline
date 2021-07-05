
using ShopOnline.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.ViewModels.Catalog.Products
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
        //them categoryId để tìm kiếm
        public List<int> CategoryIds { get; set; }
        public string LanguageId { get; set; }
    }
}
