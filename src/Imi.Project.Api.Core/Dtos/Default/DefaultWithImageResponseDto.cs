using Imi.Project.Api.Core.Dtos.Default;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Default
{
    public class DefaultWithImageResponseDto : DefaultResponseDto
    {
        public Uri Image { get; set; }
    }
}
