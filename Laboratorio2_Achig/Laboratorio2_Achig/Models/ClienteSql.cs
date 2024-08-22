using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace Laboratorio2_Achig.Models
{
    public class ClienteSql
    {
        public int Codigo { get; set; }

        public string Provincia { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [StringLength(10, ErrorMessage = "La cédula no puede tener más de 10 caracteres.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "El campo debe contener solo letras")]
        [StringLength(50, ErrorMessage = "Los apellidos no pueden tener más de 50 caracteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "El campo debe contener solo letras.")]
        [StringLength(50, ErrorMessage = "Los nombres no pueden tener más de 50 caracteres.")]
        public string Nombres { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1950-01-01", "2006-12-31", ErrorMessage = "La fecha debe estar entre el 01 de enero de 1950 y el 31 de diciembre de 2006.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string Mail { get; set; }

        [RegularExpression(@"^\d{1,10}$", ErrorMessage = "El teléfono debe contener solo números y tener hasta 10 dígitos.")]
        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public bool Estado { get; set; }

        [RegularExpression(@"^\d{1,10}(,\d{0,2})?$", ErrorMessage = "Número no válido. Debe tener hasta 10 dígitos enteros y hasta 2 decimales.")]
        [Range(0, double.MaxValue, ErrorMessage = "El saldo no puede ser negativo.")]
        public decimal Saldo { get; set; }
    }
}