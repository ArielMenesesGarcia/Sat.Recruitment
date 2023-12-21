using System;
using System.ComponentModel.DataAnnotations;
using Sat.Recruitment.Transversal.Common.Filters;

namespace Sat.Recruitment.Application.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Por favor envie un Nombre para agregar")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Por favor envie un Nombre para agregar")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        [IsNumericPhone]
        public string Phone { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor ingrese un valor de moneda")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$",ErrorMessage = "El formato agregado no es correcto")]
        [Range(99, 99999999)]
        public decimal Money { get; set; }
    }
}
