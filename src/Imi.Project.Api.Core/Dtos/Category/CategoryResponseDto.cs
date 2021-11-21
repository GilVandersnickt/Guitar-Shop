﻿using Imi.Project.Api.Core.Dtos.Default;
using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Dtos
{
    public class CategoryResponseDto : DtoBase
    {
        public string Name { get; set; }
        public Uri Image { get; set; }
        public ICollection<DefaultResponseDto> Brands { get; set; }
        public ICollection<DefaultResponseDto> Subcategories { get; set; }
        public ICollection<ProductResponseDto> Products { get; set; }
    }
}
