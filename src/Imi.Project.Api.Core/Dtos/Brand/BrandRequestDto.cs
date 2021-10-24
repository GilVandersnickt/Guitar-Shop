using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Dtos
{
    public class BrandRequestDto : DtoBase
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        public Uri Image { get; set; }
    }
}
