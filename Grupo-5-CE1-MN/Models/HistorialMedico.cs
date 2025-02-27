using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Grupo_5_CE1_MN.Models
{
    public class HistorialMedico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El diagnóstico es obligatorio")]
        [StringLength(500, ErrorMessage = "El diagnóstico no puede exceder los 500 caracteres")]
        [Display(Name = "Diagnóstico")]
        public string Diagnostico { get; set; }

        [Required(ErrorMessage = "El tratamiento es obligatorio")]
        [StringLength(500, ErrorMessage = "El tratamiento no puede exceder los 500 caracteres")]
        [Display(Name = "Tratamiento")]
        public string Tratamiento { get; set; }

        [Required(ErrorMessage = "La fecha de registro es obligatoria")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        [StringLength(500, ErrorMessage = "La receta médica no puede exceder los 500 caracteres")]
        [Display(Name = "Receta Médica")]
        public string RecetaMedica { get; set; }

        [ForeignKey("Paciente")]
        public int PacienteIDHM { get; set; }
        public virtual Paciente Paciente { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorIDHM { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}



