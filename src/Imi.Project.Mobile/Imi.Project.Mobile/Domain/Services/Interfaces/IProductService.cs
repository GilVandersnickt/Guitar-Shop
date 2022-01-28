using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Models.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> Get(Guid id);
        Task<List<Product>> Get();
        Task<ProductResponse> Update(ProductRequest entity);
        Task<Product> Delete(Guid id);
        Task<ProductResponse> Add(ProductRequest entity);
        Task<List<Product>> GetProductsByBrand(Brand brand);
        Task<List<Product>> GetProductsByCategory(Category category);
        Task<bool> AddImage(Guid id, Stream entity);
    }
}
