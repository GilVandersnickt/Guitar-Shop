using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Entities
{
    public class Subcategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<BrandSubcategory> BrandSubcategories { get; set; }
    }
}
