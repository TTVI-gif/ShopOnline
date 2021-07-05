using ShopOnline.ViewModels.Common;
using ShopOnline.ViewModels.System.Language;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.Application.System.Language
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageViewModel>>> GetAll();
    }
}
