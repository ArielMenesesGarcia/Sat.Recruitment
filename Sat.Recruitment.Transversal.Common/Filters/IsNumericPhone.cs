using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sat.Recruitment.Transversal.Common.Filters
{
    public class IsNumericPhone : ValidationAttribute
    {
        protected override  ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value != null)
            {
                if (value.ToString().Length > 10)
                    return new ValidationResult("Por favor ingrese solo 10 numeros");

                decimal valuePhone;
                var isNumeric = decimal.TryParse(value.ToString(), out valuePhone);

                if (!isNumeric)
                {
                    return new ValidationResult("Por favor solo ingresa numeros sin espacios ni letras.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
