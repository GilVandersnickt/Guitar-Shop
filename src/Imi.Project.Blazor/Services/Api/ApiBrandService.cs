using Imi.Project.Blazor.Constants;
using Imi.Project.Blazor.Models.Api;
using Imi.Project.Blazor.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class ApiBrandService : IBrandService
    {
        public async Task<List<BrandResponse>> Get()
        {
            var brands = await WebApiClient.GetApiResult<List<BrandResponse>>($"{ApiSettings.BaseUri}brands");
            return brands.ToList();
        }
    }
}
