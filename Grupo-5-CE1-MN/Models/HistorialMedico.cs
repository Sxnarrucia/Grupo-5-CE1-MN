using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo_5_CE1_MN.Models
{
    public class HistorialMedico
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Paciente")]
        [Required(ErrorMessage = "Debe seleccionar un paciente")]
        public int PacienteID { get; set; }
        public virtual Paciente Paciente { get; set; }

        [ForeignKey("Doctor")]
        [Required(ErrorMessage = "Debe seleccionar un doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }

        [Required(ErrorMessage = "El diagnóstico es obligatorio")]
        [StringLength(500, ErrorMessage = "El diagnóstico no puede exceder los 500 caracteres")]
        [Display(Name = "Diagnóstico")]
        public string Diagnostico { get; set; }

        [Required(ErrorMessage = "El tratamiento es obligatorio")]
        [StringLength(500, ErrorMessage = "El tratamiento no puede exceder los 500 caracteres")]
        [Display(Name = "Tratamiento")]
        public string Tratamiento { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [StringLength(500, ErrorMessage = "La receta médica no puede exceder los 500 caracteres")]
        [Display(Name = "Receta Médica")]
        public string RecetaMedica { get; set; }

        public bool DiagnosticoValido()
        {
            return !string.IsNullOrWhiteSpace(Diagnostico) && Diagnostico.Length > 10;
        }
    }
}
