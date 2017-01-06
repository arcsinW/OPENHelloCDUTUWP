using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.ComponentModel
{
    public class MustTrueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((bool)value == true)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("");
            }
        }
    }
}
