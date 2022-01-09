using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Blazor.Models
{
    public class ProductItem
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Title is too long.")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
        public InputSelectItem[] Categories { get; set; }
        public Guid BrandId { get; set; }
        public InputSelectItem[] Brands { get; set; }
    }
}
