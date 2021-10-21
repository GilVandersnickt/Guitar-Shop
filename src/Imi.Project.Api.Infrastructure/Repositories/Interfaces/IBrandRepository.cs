using Imi.Project.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories.Interfaces
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        Task<IEnumerable<Brand>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Brand>> GetBySubcategoryIdAsync(Guid id);
        Task<IEnumerable<Brand>> SearchAsync(string search);

    }
}
