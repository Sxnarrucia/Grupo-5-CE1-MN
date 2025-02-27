namespace Grupo_5_CE1_MN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CE01Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CitaMedicas",
                c => new
                    {
                        IdCita = c.Int(nullable: false, identity: true),
                        PacienteID = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        FechaCita = c.DateTime(nullable: false),
                        HoraCita = c.DateTime(nullable: false),
                        EstadoCita = c.String(nullable: false, maxLength: 50),
                        MotivoCita = c.String(nullable: false, maxLength: 100),
                        NotasDoctor = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdCita)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.PacienteID, cascadeDelete: true)
                .Index(t => t.PacienteID)
                .Index(t => t.DoctorID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellidos = c.String(nullable: false, maxLength: 150),
                        NumeroLicenciaMedica = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(),
                        Correo = c.String(),
                        Especialidad = c.String(nullable: false, maxLength: 100),
                        HoraInicioJornada = c.DateTime(nullable: false),
                        HoraFinJornada = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellidos = c.String(nullable: false, maxLength: 150),
                        Telefono = c.String(),
                        Correo = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Direccion = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistorialMedicoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacienteId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Diagnostico = c.String(nullable: false, maxLength: 500),
                        Tratamiento = c.String(nullable: false, maxLength: 500),
                        FechaRegistro = c.DateTime(nullable: false),
                        RecetaMedica = c.String(maxLength: 500),
                        PacienteID = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.PacienteID, cascadeDelete: true)
                .Index(t => t.PacienteID)
                .Index(t => t.DoctorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistorialMedicoes", "PacienteID", "dbo.Pacientes");
            DropForeignKey("dbo.HistorialMedicoes", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.CitaMedicas", "PacienteID", "dbo.Pacientes");
            DropForeignKey("dbo.CitaMedicas", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.HistorialMedicoes", new[] { "DoctorID" });
            DropIndex("dbo.HistorialMedicoes", new[] { "PacienteID" });
            DropIndex("dbo.CitaMedicas", new[] { "DoctorID" });
            DropIndex("dbo.CitaMedicas", new[] { "PacienteID" });
            DropTable("dbo.HistorialMedicoes");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Doctors");
            DropTable("dbo.CitaMedicas");
        }
    }
}
