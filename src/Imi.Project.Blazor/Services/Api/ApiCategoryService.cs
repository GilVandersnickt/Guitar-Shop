using Imi.Project.Blazor.Constants;
using Imi.Project.Blazor.Models.Api;
using Imi.Project.Blazor.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class ApiCategoryService : ICategoryService
    {
        public async Task<List<CategoryResponse>> Get()
        {
            var categories = await WebApiClient.GetApiResult<List<CategoryResponse>>($"{ApiSettings.BaseUri}categories");
            return categories.ToList();
        }
    }
}
