using Imi.Project.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAllAsync(); 
        Task<IEnumerable<T>> ListAllAsync(); 
        Task<T> GetByIdAsync(Guid id); 
        Task<T> UpdateAsync(T entity); 
        Task<T> AddAsync(T entity); 
        Task<T> DeleteAsync(T entity);
    }
}
