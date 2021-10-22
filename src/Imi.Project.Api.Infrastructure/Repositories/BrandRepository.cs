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
    public class BrandRepository : EfRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Brand> GetAllAsync()
        {
            return _dbContext.Brands
                .Include(b => b.Products)
                .Include(b => b.BrandCategories).ThenInclude(b => b.Category)
                .Include(b => b.BrandSubcategories).ThenInclude(b => b.Subcategory);
        }
        public async override Task<IEnumerable<Brand>> ListAllAsync()
        {
            var brands = await GetAllAsync().ToListAsync();
            return brands;
        }
        public async override Task<Brand> GetByIdAsync(Guid id)
        {
            var brand = await GetAllAsync().SingleOrDefaultAsync(b => b.Id.Equals(id));
            return brand;
        }
        public async Task<IEnumerable<Brand>> GetBySubcategoryIdAsync(Guid id)
        {
            var brands = await GetAllAsync().Where(b => b.BrandSubcategories.Any(bs => bs.SubcategoryId.Equals(id))).ToListAsync();
            return brands;
        }
        public async Task<IEnumerable<Brand>> GetByCategoryIdAsync(Guid id)
        {
            var brands = await GetAllAsync().Where(b => b.BrandCategories.Any(bc => bc.CategoryId.Equals(id))).ToListAsync();
            return brands;
        }
        public async Task<IEnumerable<Brand>> SearchAsync(string search)
        {
            var brands = await GetAllAsync()
                .Where(b => b.Name.Contains(search.Trim().ToUpper()))
                .ToListAsync();

            return brands;
        }
    }
}
