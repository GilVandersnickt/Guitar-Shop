using Imi.Project.Wpf.ApiModels.Product;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Imi.Project.Wpf.Services
{
    public class ProductsService
    {
        public StringContent GetProductRequest(string name, Uri image, string price, Guid brandId, Guid categoryId, Guid subcategoryId)
        {
            var request = new ProductApiRequest
            {
                Name = name,
                Image = image,
                Price = price,
                BrandId = brandId,
                CategoryId = categoryId,
                SubcategoryId = subcategoryId
            };
            return new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        }
        public StringContent GetProductRequest(Guid id, string name, Uri image, string price, Guid brandId, Guid categoryId, Guid subcategoryId)
        {
            var request = new ProductApiRequest
            {
                Id = id,
                Name = name,
                Image = image,
                Price = price,
                BrandId = brandId,
                CategoryId = categoryId,
                SubcategoryId = subcategoryId
            };
            return new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        }
    }
}
