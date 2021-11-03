using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private static List<Category> categories = new List<Category>
        {
            #region Seeding

                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    Name = "Electric guitars",
                    Image = "Electric_Guitars.PNG"
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    Name = "Amps",
                    Image= "Amps.PNG"
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    Name = "Bass guitars",
                    Image= "Bass_Guitars.PNG"
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000004"),
                    Name = "Classical guitars",
                    Image= "Classical_Guitars.PNG"
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000005"),
                    Name = "Cables",
                    Image= "Cables.PNG"
                },
#endregion
        };

        public async Task<Category> Add(Category category)
        {
            categories.Add(category);
            return await Task.FromResult(category);
        }

        public async Task<Category> Delete(Guid id)
        {
            var oldCategoryList = categories.FirstOrDefault(e => e.Id == id);
            categories.Remove(oldCategoryList);
            return await Task.FromResult(oldCategoryList);
        }

        public async Task<List<Category>> Get()
        {
            return await Task.FromResult(categories);
        }

        public async Task<Category> Get(Guid id)
        {
            var category = categories.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(category);
        }

        public async Task<Category> Update(Category category)
        {
            var oldBucketList = categories.FirstOrDefault(e => e.Id == category.Id);
            categories.Remove(oldBucketList);
            categories.Add(category);
            return await Task.FromResult(category);
        }
    }
}
