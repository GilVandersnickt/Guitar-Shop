using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Services.Validation
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        int _minAge;
        public MinimumAgeAttribute(int minAge)
        {
            _minAge = minAge;
        }
        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(_minAge) < DateTime.Now;
            }
            return false;
        }
    }
}
