using System.ComponentModel.DataAnnotations;

namespace Laboratorio1P3AchigSteven.Models
{
    public class ClienteSql
    {
        /*Observar cuales son los usos que se le pueden dar al required con mensajes, numero maximo del tamaño del ingreso*/
        public int Codigo { get; set; }

        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }
        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set;}
        public string Mail { get; set; }
        [MaxLength(10, ErrorMessage = "El numero de telefeono debe ser de 10 digitos")]
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public Boolean Estado { get; set; }

    }
}