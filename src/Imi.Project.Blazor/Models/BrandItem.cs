using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Blazor.Models
{
    public class BrandItem
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
