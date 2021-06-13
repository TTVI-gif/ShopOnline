using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Entiiies
{
    public class Product
    {
        public int ID { get; set; }
        public Decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
        

        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public List<Carts> Carts { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; }
    }
}
