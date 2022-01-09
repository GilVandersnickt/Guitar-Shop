using Imi.Project.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class ProductsService : ICRUDService<ProductListItem, ProductItem>
    {
        private readonly CategoriesService categoriesService;
        private readonly BrandsService brandsService;
        static List<ProductItem> products = new List<ProductItem>
        {
            #region Seeding
            
                new ProductItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Fender eric clapton stratocaster almond green",
                    Price = 1000M,
                    Image = "fenderericclaptonstratocastermnalmondgreenmasterbuilttoddkrausecz552554GIT0057454000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001")
                },
                new ProductItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                    Name = "Gibson les paul studio smokehouse burst",
                    Price = 1000M,
                    Image = "gibsonlespaulstudiosmokehouseburstGIT0049498000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001")
                },
                new ProductItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                    Name = "Gretsch g5230t electromatic jet ft single cut bigsby airline silver",
                    Price = 1000M,
                    Image = "gretschg5230telectromaticjetftsinglecutbigsbyairlinesilverGIT0047791000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000003"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001")
                },
                new ProductItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                    Name = "Fender 64 custom deluxe reverb",
                    Price = 1000M,
                    Image = "fender64customdeluxereverbGIT0042604000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002")
                },
                new ProductItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000030"),
                    Name = "Fender american original 60s precision bass rw surf green",
                    Price = 1000M,
                    Image = "fenderamericanoriginal60sprecisionbassrwsurfgreenBAS0010757000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003")
                },
                new ProductItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000037"),
                    Name = "Yamaha c 40 m",
                    Price = 1000M,
                    Image = "yamahac40mmatGIT0019253000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000004")
                },
                new ProductItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000039"),
                    Name = "Roland ric bpc patchcable 0,15m",
                    Price = 1000M,
                    Image = "rolandricbpcpatchkabel015mACC0007020000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005")
                },

            #endregion
        };

        public ProductsService()
        {
            categoriesService = new CategoriesService();
            brandsService = new BrandsService();
        }
        public Task<ProductListItem[]> GetList()
        {
            return Task.FromResult(products.Select(x => new ProductListItem()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Image = x.Image,
                Brand = brandsService.GetSelectList().Result
                    .Where(y => y.Value == x.CategoryId.ToString())
                    .Select(y => y.Label)
                    .SingleOrDefault(),
                Category = categoriesService.GetSelectList().Result
                    .Where(y => y.Value == x.CategoryId.ToString())
                    .Select(y => y.Label)
                    .SingleOrDefault()
            }).ToArray());
        }
        public Task<ProductItem> GetNew()
        {
            var product = new ProductItem();
            product.Brands = brandsService.GetSelectList().Result;
            product.BrandId = Guid.Parse(brandsService.GetSelectList().Result.First().Value);
            product.Categories = categoriesService.GetSelectList().Result;
            product.CategoryId = Guid.Parse(categoriesService.GetSelectList().Result.First().Value);
            return Task.FromResult(product);
        }
        public Task<ProductItem> Get(Guid id)
        {
            var product = products.SingleOrDefault(x => x.Id == id);
            product.Brands = brandsService.GetSelectList().Result;
            product.Categories = categoriesService.GetSelectList().Result;
            return Task.FromResult(product);
        }
        public Task Create(ProductItem item)
        {
            item.Id = Guid.NewGuid();
            products.Add(item);
            return Task.CompletedTask;
        }
        public Task Update(ProductItem item)
        {
            var product = products.SingleOrDefault(x => x.Id == item.Id);
            if (product == null) throw new ArgumentException("product not found!");
            product.Name = item.Name;
            product.Price = item.Price;
            product.Image = item.Image;
            product.CategoryId = item.CategoryId;
            product.BrandId = item.BrandId;
            return Task.CompletedTask;
        }
        public Task Delete(Guid id)
        {
            var product = products.SingleOrDefault(x => x.Id == id);
            if (product == null) throw new ArgumentException("product not found!");
            products.Remove(product);
            return Task.CompletedTask;
        }
    }
}
