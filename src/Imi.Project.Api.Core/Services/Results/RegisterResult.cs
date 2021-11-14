﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Services.Results
{
    public class RegisterResult
    {
        public bool Succeeded { get; set; }
        public ICollection<string> ErrorMessages { get; set; }
    }
}
