using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class ProductsService : ICRUDService<ProductListItem, ProductItem>
    {

        static InputSelectItem[] categories = new InputSelectItem[]
        {
            new InputSelectItem() { Value = "1", Label = "Electric guitars" },
            new InputSelectItem() { Value = "2", Label = "Acoustic guitars" },
            new InputSelectItem() { Value = "3", Label = "Classical guitars" },
            new InputSelectItem() { Value = "4", Label = "Bass guitars" }
        };
        static List<ProductItem> products = new List<ProductItem>
        {
            new ProductItem() { Id = 1, Title = "Fender Stratocaster ultra burst", CategoryId = "1", Price = "1500,00" },
            new ProductItem() { Id = 2, Title = "Taylor 314ce V-Class", CategoryId = "2", Price = "500,00" },
            new ProductItem() { Id = 3, Title = "Yamaha NCX1C Natural", CategoryId = "3", Price = "300,00" },
            new ProductItem() { Id = 4, Title = "Fender Player jazz bass", CategoryId = "4", Price = "750,00" },
        };
        public Task<ProductListItem[]> GetList()
        {
            return Task.FromResult(products.Select(x => new ProductListItem()
            {
                Id = x.Id,
                Title = x.Title,
                Category = categories
                    .Where(y => y.Value == x.CategoryId)
                    .Select(y => y.Label)
                    .SingleOrDefault()
            }).ToArray());
        }
        public Task<ProductItem> GetNew()
        {
            var product = new ProductItem();
            product.Categories = categories;
            product.CategoryId = categories.First().Value;
            return Task.FromResult(product);
        }
        public Task<ProductItem> Get(int id)
        {
            var product = products.SingleOrDefault(x => x.Id == id);
            product.Categories = categories;
            return Task.FromResult(product);
        }
        public Task Create(ProductItem item)
        {
            item.Id = products.Count() > 0 ? products.Max(x => x.Id) + 1 : 1;
            products.Add(item);
            return Task.CompletedTask;
        }
        public Task Update(ProductItem item)
        {
            var product = products.SingleOrDefault(x => x.Id == item.Id);
            if (product == null) throw new ArgumentException("product not found!");
            product.Title = item.Title;
            product.CategoryId = item.CategoryId;
            product.Price = item.Price;
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var product = products.SingleOrDefault(x => x.Id == id);
            if (product == null) throw new ArgumentException("product not found!");
            products.Remove(product);
            return Task.CompletedTask;
        }
    }
}
