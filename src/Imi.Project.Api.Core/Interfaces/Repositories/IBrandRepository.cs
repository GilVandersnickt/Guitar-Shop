using Imi.Project.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<IEnumerable<Brand>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Brand>> GetBySubcategoryIdAsync(Guid id);
    }
}
