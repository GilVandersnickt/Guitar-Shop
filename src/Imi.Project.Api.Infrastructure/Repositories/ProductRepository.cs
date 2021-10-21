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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public override IQueryable<Product> GetAll()
        {
            return _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Subcategory);
        }

        public async override Task<IEnumerable<Product>> ListAllAsync()
        {
            var products = await GetAll().ToListAsync();
            return products;
        }

        public async override Task<Product> GetByIdAsync(Guid id)
        {
            var product = await GetAll().SingleOrDefaultAsync(p => p.Id.Equals(id));
            return product;
        }

        public async Task<IEnumerable<Product>> GetByBrandIdAsync(Guid id)
        {
            var products = await GetAll().Where(p => p.BrandId.Equals(id)).ToListAsync();
            return products;
        }
        public async Task<IEnumerable<Product>> GetBySubcategoryIdAsync(Guid id)
        {
            var products = await GetAll().Where(p => p.SubcategoryId.Equals(id)).ToListAsync();
            return products;
        }
        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id)
        {
            var products = await GetAll().Where(p => p.CategoryId.Equals(id)).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> SearchAsync(string search)
        {
            var products = await GetAll()
                .Where(p => p.Name.Contains(search.Trim().ToUpper()) || p.Category.Name.Contains(search.Trim().ToUpper()))
                .ToListAsync();

            return products;
        }
    }
}
