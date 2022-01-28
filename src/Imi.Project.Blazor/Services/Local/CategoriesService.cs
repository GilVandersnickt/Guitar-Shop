using Imi.Project.Blazor.Models.Local;
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
            #region Seeding
                new CategoryItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    Name = "Electric guitars",
                    Image = "Electric_Guitars.PNG"
                },
                new CategoryItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    Name = "Amps",
                    Image= "Amps.PNG"
                },
                new CategoryItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    Name = "Bass guitars",
                    Image= "Bass_Guitars.PNG"
                },
                new CategoryItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000004"),
                    Name = "Classical guitars",
                    Image= "Classical_Guitars.PNG"
                },
                new CategoryItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000005"),
                    Name = "Cables",
                    Image= "Cables.PNG"
                },
            #endregion
        };
        static InputSelectItem[] categoriesSelectList = new InputSelectItem[]
            {
                new InputSelectItem() { Value = Guid.Parse("00000000-0000-0000-0002-000000000001").ToString(), Label = "Electric guitars" },
                new InputSelectItem() { Value = Guid.Parse("00000000-0000-0000-0002-000000000002").ToString(), Label = "Amps" },
                new InputSelectItem() { Value = Guid.Parse("00000000-0000-0000-0002-000000000003").ToString(), Label = "Acoustic guitars" },
                new InputSelectItem() { Value = Guid.Parse("00000000-0000-0000-0002-000000000004").ToString(), Label = "Classical guitars" },
                new InputSelectItem() { Value = Guid.Parse("00000000-0000-0000-0002-000000000005").ToString(), Label = "Bass guitars" }
            };

        public Task<CategoryListItem[]> GetList()
        {
            return Task.FromResult(
                categories.Select(x => new CategoryListItem()
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Image = x.Image
                }).ToArray()
            );
        }
        public Task<InputSelectItem[]> GetSelectList()
        {
            return Task.FromResult(
                categories.Select(x => new InputSelectItem()
                {
                    Value = x.Id.ToString(),
                    Label = x.Name
                }).ToArray()
            );
        }
        public Task<CategoryItem> GetNew()
        {
            return Task.FromResult(new CategoryItem());
        }
        public Task<CategoryItem> Get(Guid id)
        {
            return Task.FromResult(categories.SingleOrDefault(x => x.Id == id));
        }
        public Task Create(CategoryItem item)
        {
            item.Id = Guid.NewGuid();
            categories.Add(item);
            return Task.CompletedTask;
        }
        public Task Update(CategoryItem item)
        {
            var category = categories.SingleOrDefault(x => x.Id == item.Id);
            if (category == null) throw new ArgumentException("Category not found!");
            category.Name = item.Name;
            category.Image = item.Image;
            return Task.CompletedTask;
        }
        public Task Delete(Guid id)
        {
            var category = categories.SingleOrDefault(x => x.Id == id);
            if (category == null) throw new ArgumentException("Category not found!");
            categories.Remove(category);
            return Task.CompletedTask;
        }
    }
}
