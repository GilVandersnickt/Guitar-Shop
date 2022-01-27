using Imi.Project.Blazor.Constants;
using Imi.Project.Blazor.Models.Api;
using Imi.Project.Blazor.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class ApiSubcategoryService : ISubcategoryService
    {
        public async Task<List<SubcategoryResponse>> Get()
        {
            var subcategories = await WebApiClient.GetApiResult<List<SubcategoryResponse>>($"{ApiSettings.BaseUri}subcategories");
            return subcategories.ToList();
        }
    }
}
