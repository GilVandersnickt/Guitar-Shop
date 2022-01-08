using Imi.Project.Mobile.Constants;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class ApiCategoryService : ICategoryService
    {
        public ApiCategoryService()
        {

        }
        public async Task<Category> Add(Category category)
        {
            return await WebApiClient.PostCallApi<Category, Category>($"{ApiSettings.BaseUri}Categories", category);
        }

        public async Task<Category> Delete(Guid id)
        {
            return await WebApiClient.DeleteCallApi<Category>($"{ApiSettings.BaseUri}Categories/{id}");
        }

        public async Task<Category> Get(Guid id)
        {
            return await WebApiClient.GetApiResult<Category>($"{ApiSettings.BaseUri}Categories/{id}");
        }

        public async Task<List<Category>> Get()
        {
            return await WebApiClient.GetApiResult<List<Category>>($"{ApiSettings.BaseUri}Categories");
        }

        public async Task<Category> Update(Category category)
        {
            return await WebApiClient.PutCallApi<Category, Category>($"{ApiSettings.BaseUri}Categories", category);
        }

    }
}
