using Imi.Project.Mobile.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface IProductService : ICrudService<Product>
    {
        Task<List<Product>> GetProductsByBrand(Brand brand);
        Task<List<Product>> GetProductsByCategory(Category category);
    }
}
