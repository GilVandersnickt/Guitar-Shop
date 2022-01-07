using Imi.Project.Mobile.Constants;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return await WebApiClient.PostCallApi<Category, Category>($"{ApiSettings.BaseUri}categories", category);
        }

        public async Task<Category> Delete(Guid id)
        {
            return await WebApiClient.DeleteCallApi<Category>($"{ApiSettings.BaseUri}categories/{id}");
        }

        public async Task<Category> Get(Guid id)
        {
            return await WebApiClient.GetApiResult<Category>($"{ApiSettings.BaseUri}categories/{id}");
        }

        public async Task<List<Category>> Get()
        {
            var category = await WebApiClient.GetApiResult<List<Category>>($"{ApiSettings.BaseUri}categories");
            return category.ToList();
        }

        public async Task<Category> Update(Category category)
        {
            return await WebApiClient.PutCallApi<Category, Category>($"{ApiSettings.BaseUri}categories/{category.Id}", category);
        }

    }
}
