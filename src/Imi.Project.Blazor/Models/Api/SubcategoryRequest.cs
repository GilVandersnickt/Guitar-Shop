using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Blazor.Models.Api
{
    public class SubcategoryRequest
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
