using Imi.Project.Mobile.Constants;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Models.Api;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    class ApiProductService : IProductService
    {
        public ApiProductService()
        {

        }
        public async Task<ProductResponse> Add(ProductRequest product)
        {
            return await WebApiClient.PostCallApi<ProductResponse, ProductRequest>($"{ApiSettings.BaseUri}Products", product);
        }

        public async Task<Product> Delete(Guid id)
        {
            return await WebApiClient.DeleteCallApi<Product>($"{ApiSettings.BaseUri}Products/{id}");
        }

        public async Task<Product> Get(Guid id)
        {
            return await WebApiClient.GetApiResult<Product>($"{ApiSettings.BaseUri}Products/{id}");
        }

        public async Task<List<Product>> Get()
        {
            var product = await WebApiClient.GetApiResult<List<Product>>($"{ApiSettings.BaseUri}Products");
            return product.ToList();
        }

        public async Task<List<Product>> GetProductsByBrand(Brand brand)
        {
            var products = await WebApiClient.GetApiResult<List<Product>>($"{ApiSettings.BaseUri}Brands/{brand.Id}/Products");
            return products.ToList();
        }

        public async Task<List<Product>> GetProductsByCategory(Category category)
        {
            var products = await WebApiClient.GetApiResult<List<Product>>($"{ApiSettings.BaseUri}Categories/{category.Id}/Products");
            return products.ToList();
        }

        public async Task<ProductResponse> Update(ProductRequest product)
        {
            return await WebApiClient.PutCallApi<ProductResponse, ProductRequest>($"{ApiSettings.BaseUri}Products", product);
        }
        public async Task<bool> AddImage(Guid id, Stream image)
        {
            return await WebApiClient.UploadImage(id, image, $"{ApiSettings.BaseUri}Products/{id}/Image");
        }

    }
}
