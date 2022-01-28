using Imi.Project.Blazor.Models.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponse> Get(Guid id);
        Task<List<ProductResponse>> Get();
        Task<ProductResponse> Update(ProductRequest entity);
        Task<ProductResponse> Delete(Guid id);
        Task<ProductResponse> Add(ProductRequest entity);
        Task<bool> AddImage(Guid id, Stream entity);
        Task<ProductRequestForm> GetRequest();
        Task<ProductRequestForm> GetRequest(ProductResponse product, ProductRequestForm baseRequest);
        Task<ProductRequest> GetRequest(ProductRequestForm requestForm);
    }
}
