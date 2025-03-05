using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo_5_CE1_MN.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del doctor es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos del doctor son obligatorios")]
        [StringLength(150)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El número de licencia médica es obligatorio")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string NumeroLicenciaMedica { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [Phone(ErrorMessage = "El número de teléfono no es válido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido")]
        [StringLength(255, ErrorMessage = "El correo no puede ser mayor a 255 caracteres")]
        [Index(IsUnique = true)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(100)]
        public string Especialidad { get; set; }

        [Required(ErrorMessage = "La hora de inicio de jornada es obligatoria")]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicioJornada { get; set; }

        [Required(ErrorMessage = "La hora de fin de jornada es obligatoria")]
        [DataType(DataType.Time)]
        public TimeSpan HoraFinJornada { get; set; }

       
        public bool EsHorarioValido()
        {
            return HoraFinJornada > HoraInicioJornada;
        }
    }
}
