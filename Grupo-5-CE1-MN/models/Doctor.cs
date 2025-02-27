using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public string NumeroLicenciaMedica { get; set; }

        [Phone(ErrorMessage = "El número de teléfono no es válido")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(100)]
        public string Especialidad { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora de inicio de jornada")]
        public DateTime HoraInicioJornada { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora de fin de jornada")]
        public DateTime HoraFinJornada { get; set; }
    }
} 


    
