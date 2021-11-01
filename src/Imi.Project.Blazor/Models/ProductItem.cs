using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }
        public string CategoryId { get; set; }
        public InputSelectItem[] Categories { get; set; }
        public string Price { get; set; }
    }
}
