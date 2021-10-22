using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Entities
{
    public class Product : BaseEntity
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
