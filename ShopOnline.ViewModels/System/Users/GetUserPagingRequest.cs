using ShopOnline.ViewModels.Common;

namespace ShopOnline.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
