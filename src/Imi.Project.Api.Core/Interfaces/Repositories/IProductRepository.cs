using Imi.Project.Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetByBrandIdAsync(Guid id);
        Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Product>> GetBySubcategoryIdAsync(Guid id);
        Task<IEnumerable<Product>> SearchAsync(string search);
    }
}
