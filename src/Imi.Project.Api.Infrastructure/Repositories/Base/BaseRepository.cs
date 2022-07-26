﻿using Imi.Project.Api.Core.Interfaces;
using Imi.Project.Api.Entities;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByIdAsync(Guid id, string[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.SingleOrDefaultAsync(t => t.Id.Equals(id));
        }
        public virtual IQueryable<T> GetAllAsync()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }
        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
        public IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).AsQueryable();
        }
        public async Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastEditedOn = DateTime.UtcNow;

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            entity.LastEditedOn = DateTime.UtcNow;

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            await DeleteAsync(entity);
            return entity;
        }
    }
}
