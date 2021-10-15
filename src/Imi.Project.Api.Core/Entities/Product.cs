using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Entities
{
    public class Product : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Uri Image { get; set; }
        [Required]
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public Guid SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
