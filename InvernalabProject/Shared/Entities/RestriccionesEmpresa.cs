using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvernalabProject.Shared.Entities
{
    public class RestriccionesEmpresa
    {
        

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "El nombre no puede contener espacios.")]
        public string Nombre { get; set; }


        public IFormFile? logo { get; set; }


        public int Estado { get; set; } 

        [Required(ErrorMessage = "El campo Nit es obligatorio.")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "El campo Nit debe ser una cadena de 9 dígitos.")]
        public string Nit { get; set; }


        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Usuario debe ser una dirección de correo electrónico válida.")]
        [StringLength(50, ErrorMessage = "El campo Nombre no puede exceder los 50 caracteres.")]
        public string Usuario { get; set; }


        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "La Contraseña no puede contener espacios.")]
        public string Contraseña { get; set; }


        public DateTime FechaInsert { get; set; }
    }
}
