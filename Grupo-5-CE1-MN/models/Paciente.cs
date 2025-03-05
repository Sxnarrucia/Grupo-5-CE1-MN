using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo_5_CE1_MN.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del paciente es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos del paciente son obligatorios")]
        [StringLength(150)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [Phone(ErrorMessage = "El número de teléfono no es válido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido")]
        [StringLength(255, ErrorMessage = "El correo no puede ser mayor a 255 caracteres")]
        [Index(IsUnique = true)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria")]
        [StringLength(20, ErrorMessage = "La cédula no puede superar los 20 caracteres")]
        [Index(IsUnique = true)]
        public string Cedula { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(250)]
        public string Direccion { get; set; }
    }
}
