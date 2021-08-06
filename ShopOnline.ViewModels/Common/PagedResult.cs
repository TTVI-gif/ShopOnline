using System.Collections.Generic;

namespace ShopOnline.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }

    }
}
