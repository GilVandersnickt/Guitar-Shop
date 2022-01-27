using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Blazor.Models.Api
{
    public class ProductRequest
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        public string Price { get; set; }
        public Uri Image { get; set; }
        [Required(ErrorMessage = "Brand is required.")]
        public Guid BrandId { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "Subcategory is required.")]
        public Guid SubcategoryId { get; set; }
    }
}
