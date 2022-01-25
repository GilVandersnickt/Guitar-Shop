using Imi.Project.Api.Core.Services.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.User
{
    public class RegisterUserRequestDto : DtoBase
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        //[JsonPropertyName("email_address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [MinimumAge(0)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Address { get; set; }
        [DataType(DataType.PostalCode)]
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string City { get; set; }

    }
}
