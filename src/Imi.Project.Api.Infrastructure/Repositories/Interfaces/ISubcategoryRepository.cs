﻿using Imi.Project.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories.Interfaces
{
    public interface ISubcategoryRepository : IBaseRepository<Subcategory> 
    { 
        Task<IEnumerable<Subcategory>> GetByBrandIdAsync(Guid id);
        Task<IEnumerable<Subcategory>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Subcategory>> SearchAsync(string search);
    }
}
