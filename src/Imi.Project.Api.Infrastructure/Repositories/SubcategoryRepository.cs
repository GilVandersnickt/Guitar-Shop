using Imi.Project.Api.Entities;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class SubcategoryRepository : BaseRepository<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public override IQueryable<Subcategory> GetAll()
        {
            return _dbContext.Subcategories
                .Include(s => s.Products)
                .Include(s => s.BrandSubcategories).ThenInclude(bs => bs.Brand);
        }

        public async override Task<IEnumerable<Subcategory>> ListAllAsync()
        {
            var subcategories = await GetAll().ToListAsync();
            return subcategories;
        }

        public async override Task<Subcategory> GetByIdAsync(Guid id)
        {
            var subcategory = await GetAll().SingleOrDefaultAsync(s => s.Id.Equals(id));
            return subcategory;
        }

        public async Task<IEnumerable<Subcategory>> GetByCategoryIdAsync(Guid id)
        {
            var subcategories = await GetAll().Where(s => s.CategoryId.Equals(id)).ToListAsync();
            return subcategories;
        }
        public async Task<IEnumerable<Subcategory>> GetByBrandIdAsync(Guid id)
        {
            var subcategories = await GetAll().Where(s => s.BrandSubcategories.Any(bc => bc.BrandId.Equals(id))).ToListAsync();
            return subcategories;
        }

        public async Task<IEnumerable<Subcategory>> SearchAsync(string search)
        {
            var subcategories = await GetAll()
                .Where(s => s.Name.Contains(search.Trim().ToUpper()))
                .ToListAsync();
            return subcategories;
        }


    }
}
