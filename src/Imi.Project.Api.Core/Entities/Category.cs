using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Uri Image { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<BrandCategory> BrandCategories { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
