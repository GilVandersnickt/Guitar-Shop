using Imi.Project.Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> GetByBrandIdAsync(Guid id);
        Task<IEnumerable<Category>> SearchAsync(string search);
    }
}
