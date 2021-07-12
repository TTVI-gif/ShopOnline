using ShopOnline.ViewModels.Common;
using ShopOnline.ViewModels.System.Language;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.ApiIntegration
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageViewModel>>> GetAll();
    }
}
