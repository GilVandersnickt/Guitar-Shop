using System;
using System.ComponentModel.DataAnnotations;
namespace Imi.Project.Api.Core.Dtos
{
    public class ProductRequestDto : DtoBase
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        public string Price { get; set; }
        public Uri Image { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }

    }
}
