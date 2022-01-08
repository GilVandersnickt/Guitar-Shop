using Imi.Project.Mobile.Constants;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class ApiBrandsService : IBrandService
    {
        public ApiBrandsService()
        {

        }
        public async Task<Brand> Add(Brand brand)
        {
            return await WebApiClient.PostCallApi<Brand, Brand>($"{ApiSettings.BaseUri}brands", brand);
        }

        public async Task<Brand> Delete(Guid id)
        {
            return await WebApiClient.DeleteCallApi<Brand>($"{ApiSettings.BaseUri}brands/{id}");
        }

        public async Task<Brand> Get(Guid id)
        {
            return await WebApiClient.GetApiResult<Brand>($"{ApiSettings.BaseUri}brands/{id}");
        }

        public async Task<List<Brand>> Get()
        {
            var brands = await WebApiClient.GetApiResult<List<Brand>>($"{ApiSettings.BaseUri}brands");
            return brands.ToList();
        }

        public async Task<Brand> Update(Brand brand)
        {
            return await WebApiClient.PutCallApi<Brand, Brand>($"{ApiSettings.BaseUri}brands", brand);
        }
    }
}
