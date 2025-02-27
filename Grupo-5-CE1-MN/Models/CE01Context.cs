using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Grupo_5_CE1_MN.Models
{
    public class CE01Context : DbContext
    {
        public CE01Context() : base("name=CE01") 
        { }

        public DbSet<CitaMedica> CitaMedica { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<HistorialMedico> HistorialMedico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }

    }
}