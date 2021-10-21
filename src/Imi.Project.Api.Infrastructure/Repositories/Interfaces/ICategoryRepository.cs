using Imi.Project.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> GetByBrandIdAsync(Guid id);
        Task<IEnumerable<Category>> GetBySubcategoryIdAsync(Guid id);
        Task<IEnumerable<Category>> SearchAsync(string search);

    }
}
