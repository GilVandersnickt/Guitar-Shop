using Imi.Project.Api.Entities;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Category> GetAll()
        {
            return _dbContext.Categories
                .Include(c => c.Products)
                .Include(c => c.Subcategories)
                .Include(c => c.BrandCategories).ThenInclude(c => c.Brand);
        }

        public async override Task<IEnumerable<Category>> ListAllAsync()
        {
            var categories = await GetAll().ToListAsync();
            return categories;
        }

        public async override Task<Category> GetByIdAsync(Guid id)
        {
            var categories = await GetAll().SingleOrDefaultAsync(c => c.Id.Equals(id));
            return categories;
        }

        public async Task<IEnumerable<Category>> GetBySubcategoryIdAsync(Guid id)
        {
            var categories = await GetAll().Where(c => c.Subcategories.Any(s => s.Id.Equals(id))).ToListAsync();
            return categories;
        }
        public async Task<IEnumerable<Category>> GetByBrandIdAsync(Guid id)
        {
            var categories = await GetAll().Where(c => c.BrandCategories.Any(bc => bc.BrandId.Equals(id))).ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<Category>> SearchAsync(string search)
        {
            var categories = await GetAll()
                .Where(c => c.Name.Contains(search.Trim().ToUpper()))
                .ToListAsync();
            return categories;
        }

    }
}
