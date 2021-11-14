﻿using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Dtos.User
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}