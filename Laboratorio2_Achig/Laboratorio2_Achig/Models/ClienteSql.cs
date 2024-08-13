using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2_Achig.Models
{
    public class ClienteSql
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [StringLength(10, ErrorMessage = "La cédula no puede tener más de 10 caracteres.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [StringLength(100, ErrorMessage = "Los apellidos no pueden tener más de 100 caracteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios.")]
        [StringLength(100, ErrorMessage = "Los nombres no pueden tener más de 100 caracteres.")]
        public string Nombres { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Mail { get; set; }

        [MaxLength(10, ErrorMessage = "El número de teléfono debe ser de 10 dígitos.")]
        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public bool Estado { get; set; }
    }
}