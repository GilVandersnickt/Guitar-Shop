using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Blazor.Models.Local
{
    public class CategoryItem
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
