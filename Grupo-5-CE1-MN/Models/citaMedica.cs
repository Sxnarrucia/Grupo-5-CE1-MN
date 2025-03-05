using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo_5_CE1_MN.Models
{
    public enum EstadoCita
    {
        Pendiente,
        Confirmada,
        Cancelada,
        Atendida
    }

    public class CitaMedica
    {
        [Key]
        public int IdCita { get; set; }

        [ForeignKey("Paciente")]
        [Required(ErrorMessage = "Debe seleccionar un paciente")]
        public int PacienteID { get; set; }
        public virtual Paciente Paciente { get; set; }

        [ForeignKey("Doctor")]
        [Required(ErrorMessage = "Debe seleccionar un doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }

        [Required(ErrorMessage = "Debe especificar la fecha de la cita")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de la cita")]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "Debe especificar la hora de la cita")]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de la cita")]
        public TimeSpan HoraCita { get; set; }

        [Required(ErrorMessage = "El estado de la cita es obligatorio")]
        public EstadoCita EstadoCita { get; set; }

        [Required(ErrorMessage = "El motivo de la cita es obligatorio")]
        [StringLength(200)]
        public string MotivoCita { get; set; }

        [StringLength(500)]
        public string NotasDoctor { get; set; }

        public bool EsHorarioValido(TimeSpan inicioJornada, TimeSpan finJornada)
        {
            return HoraCita >= inicioJornada && HoraCita <= finJornada;
        }
    }
}
