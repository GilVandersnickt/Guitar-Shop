using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class CategoriesService : ICRUDService<CategoryListItem, CategoryItem>
    {
        static List<CategoryItem> categories = new List<CategoryItem>
        {
            new CategoryItem() {Id = 1, Name = "Electric guitars", Description = "All types of electric guitars"},
            new CategoryItem() {Id = 2, Name = "Acoustic guitars", Description = "All types of acoustic guitars"},
            new CategoryItem() {Id = 3, Name = "Classical guitars", Description = "All types of classical guitars"},
            new CategoryItem() {Id = 4, Name = "Bass guitars", Description = "All types of bass guitars"}
        };

        public Task<CategoryListItem[]> GetList()
        {
            return Task.FromResult(
                categories.Select(x => new CategoryListItem()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArray()
            );
        }
        public Task<CategoryItem> GetNew()
        {
            return Task.FromResult(new CategoryItem());
        }
        public Task<CategoryItem> Get(int id)
        {
            return Task.FromResult(categories.SingleOrDefault(x => x.Id == id));
        }
        public Task Create(CategoryItem item)
        {
            item.Id = categories.Count() > 0 ? categories.Max(x => x.Id) + 1 : 1;
            categories.Add(item);
            return Task.CompletedTask;
        }
        public Task Update(CategoryItem item)
        {
            var category = categories.SingleOrDefault(x => x.Id == item.Id);
            if (category == null) throw new ArgumentException("Category not found!");
            category.Name = item.Name;
            category.Description = item.Description;
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var category = categories.SingleOrDefault(x => x.Id == id);
            if (category == null) throw new ArgumentException("Category not found!");
            categories.Remove(category);
            return Task.CompletedTask;
        }
    }
}
