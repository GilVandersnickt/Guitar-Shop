﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Dtos
{
    public class CategoryRequestDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        public Uri Image { get; set; }
    }
}
