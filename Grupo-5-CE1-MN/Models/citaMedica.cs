using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Grupo_5_CE1_MN.Models
{
    public class CitaMedica
    {
        [Key]
        public int IdCita { get; set; }

        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Fecha de la cita")]
        public DateTime FechaCita { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora de la cita")]
        public DateTime HoraCita { get; set; }

        [Required(ErrorMessage = "El estado de la cita es obligatorio")]
        [StringLength(50)]
        public string EstadoCita { get; set; }

        [Required(ErrorMessage = "El motivo de la cita es obligatorio")]
        [StringLength(100)]
        public string MotivoCita { get; set; }

        [Required(ErrorMessage = "Las notas son obligatorias")]
        [StringLength(100)]
        public string NotasDoctor { get; set; }
    }
}