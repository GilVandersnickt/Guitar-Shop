using Imi.Project.Blazor.Constants;
using Imi.Project.Blazor.Models.Api;
using Imi.Project.Blazor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class ApiProductService : IProductService
    {
        public ApiProductService()
        {
        }
        public async Task<ProductResponse> Add(ProductRequest product)
        {
            return await WebApiClient.PostCallApi<ProductResponse, ProductRequest>($"{ApiSettings.BaseUri}Products", product);
        }

        public async Task<bool> AddImage(Guid id, Stream image)
        {
            return await WebApiClient.UploadImage(id, image, $"{ApiSettings.BaseUri}Products/{id}/Image");
        }
        public async Task<ProductResponse> Update(ProductRequest product)
        {
            return await WebApiClient.PutCallApi<ProductResponse, ProductRequest>($"{ApiSettings.BaseUri}Products", product);
        }

        public async Task<ProductResponse> Delete(Guid id)
        {
            return await WebApiClient.DeleteCallApi<ProductResponse>($"{ApiSettings.BaseUri}Products/{id}");
        }

        public async Task<ProductResponse> Get(Guid id)
        {
            return await WebApiClient.GetApiResult<ProductResponse>($"{ApiSettings.BaseUri}Products/{id}");
        }

        public async Task<List<ProductResponse>> Get()
        {
            var product = await WebApiClient.GetApiResult<List<ProductResponse>>($"{ApiSettings.BaseUri}Products");
            return product.ToList();
        }

        public async Task<ProductRequestForm> GetRequest()
        {
            var brands = await WebApiClient.GetApiResult<List<BrandResponse>>($"{ApiSettings.BaseUri}brands");
            var categories = await WebApiClient.GetApiResult<List<CategoryResponse>>($"{ApiSettings.BaseUri}categories");
            var subcategories = await WebApiClient.GetApiResult<List<SubcategoryResponse>>($"{ApiSettings.BaseUri}subcategories");
            return new ProductRequestForm { 
                Id = Guid.Empty, 
                Name = string.Empty, 
                Price = "0", 
                PriceDecimal = 0,
                Image = new Uri(ApiSettings.ImagePlaceHolder), 
                BrandId = brands.FirstOrDefault().Id, 
                CategoryId = categories.FirstOrDefault().Id, 
                SubcategoryId = subcategories.FirstOrDefault().Id,
                Brands = brands,
                Categories = categories,
                Subcategories = subcategories             
            };
        }

        
        public Task<ProductRequestForm> GetRequest(ProductResponse product, ProductRequestForm baseRequest)
        {
            return Task.FromResult(new ProductRequestForm
            {
                Id = product.Id,
                Name = product.Name,
                PriceDecimal = product.Price,
                Image = product.Image,
                BrandId = product.Brand.Id,
                CategoryId = product.Category.Id,
                SubcategoryId = product.Subcategory.Id,
                Brands = baseRequest.Brands,
                Categories = baseRequest.Categories,
                Subcategories = baseRequest.Subcategories,
            });
        }
        public Task<ProductRequest> GetRequest(ProductRequestForm requestForm)
        {
            return Task.FromResult(new ProductRequest
            {
                Id = requestForm.Id,
                Name = requestForm.Name,
                Price = requestForm.PriceDecimal.ToString(),
                Image = requestForm.Image,
                BrandId = requestForm.BrandId,
                CategoryId = requestForm.CategoryId,
                SubcategoryId = requestForm.SubcategoryId
            });
        }

    }
}
