using Imi.Project.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface ISubcategoryRepository : IRepository<Subcategory>
    {
        Task<IEnumerable<Subcategory>> GetByBrandIdAsync(Guid id);
        Task<IEnumerable<Subcategory>> GetByCategoryIdAsync(Guid id);
    }
}
