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
    class ApiProductService : IProductService
    {
        public ApiProductService()
        {

        }
        public async Task<Product> Add(Product product)
        {
            return await WebApiClient.PostCallApi<Product, Product>($"{ApiSettings.BaseUri}products", product);
        }

        public async Task<Product> Delete(Guid id)
        {
            return await WebApiClient.DeleteCallApi<Product>($"{ApiSettings.BaseUri}products/{id}");
        }

        public async Task<Product> Get(Guid id)
        {
            return await WebApiClient.GetApiResult<Product>($"{ApiSettings.BaseUri}products/{id}");
        }

        public async Task<List<Product>> Get()
        {
            var product = await WebApiClient.GetApiResult<List<Product>>($"{ApiSettings.BaseUri}products");
            return product.ToList();
        }

        public async Task<List<Product>> GetProductsByBrand(Brand brand)
        {
            var products = await WebApiClient.GetApiResult<IQueryable<Product>>($"{ApiSettings.BaseUri}brands/{brand.Id}/products");
            return products.ToList();
        }

        public async Task<List<Product>> GetProductsByCategory(Category category)
        {
            var products = await WebApiClient.GetApiResult<IQueryable<Product>>($"{ApiSettings.BaseUri}categories/{category.Id}/products");
            return products.ToList();
        }

        public async Task<Product> Update(Product product)
        {
            return await WebApiClient.PutCallApi<Product, Product>($"{ApiSettings.BaseUri}products/{product.Id}", product);
        }
    }
}
