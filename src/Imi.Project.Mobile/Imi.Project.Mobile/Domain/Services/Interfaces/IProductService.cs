using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Models.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> Get(Guid id);
        Task<List<Product>> Get();
        Task<Product> Update(ProductRequest entity);
        Task<Product> Delete(Guid id);
        Task<Product> Add(ProductRequest entity);
        Task<List<Product>> GetProductsByBrand(Brand brand);
        Task<List<Product>> GetProductsByCategory(Category category);
    }
}
