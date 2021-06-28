using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.ViewModels.Common
{
    public class ApiResult<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T ResultObj { get; set; }
    }
}
