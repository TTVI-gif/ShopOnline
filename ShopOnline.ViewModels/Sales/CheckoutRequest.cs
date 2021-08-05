using System.Collections.Generic;

namespace ShopOnline.ViewModels.Sales
{
    public class CheckoutRequest
    {
        public string Name { get; set; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public List<OrderDetailViewModel> OrderDetails { set; get; } = new List<OrderDetailViewModel>();
    }
}
