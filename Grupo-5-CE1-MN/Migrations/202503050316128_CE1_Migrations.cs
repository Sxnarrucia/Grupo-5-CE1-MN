namespace Grupo_5_CE1_MN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CE1_Migrations : DbMigration
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
                        HoraCita = c.Time(nullable: false, precision: 7),
                        EstadoCita = c.Int(nullable: false),
                        MotivoCita = c.String(nullable: false, maxLength: 200),
                        NotasDoctor = c.String(maxLength: 500),
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
                        Telefono = c.String(nullable: false),
                        Correo = c.String(nullable: false, maxLength: 255),
                        Especialidad = c.String(nullable: false, maxLength: 100),
                        HoraInicioJornada = c.Time(nullable: false, precision: 7),
                        HoraFinJornada = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NumeroLicenciaMedica, unique: true)
                .Index(t => t.Correo, unique: true);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellidos = c.String(nullable: false, maxLength: 150),
                        Telefono = c.String(nullable: false),
                        Correo = c.String(nullable: false, maxLength: 255),
                        Cedula = c.String(nullable: false, maxLength: 20),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Direccion = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Correo, unique: true)
                .Index(t => t.Cedula, unique: true);
            
            CreateTable(
                "dbo.HistorialMedicoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacienteID = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        Diagnostico = c.String(nullable: false, maxLength: 500),
                        Tratamiento = c.String(nullable: false, maxLength: 500),
                        FechaRegistro = c.DateTime(nullable: false),
                        RecetaMedica = c.String(maxLength: 500),
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
            DropIndex("dbo.Pacientes", new[] { "Cedula" });
            DropIndex("dbo.Pacientes", new[] { "Correo" });
            DropIndex("dbo.Doctors", new[] { "Correo" });
            DropIndex("dbo.Doctors", new[] { "NumeroLicenciaMedica" });
            DropIndex("dbo.CitaMedicas", new[] { "DoctorID" });
            DropIndex("dbo.CitaMedicas", new[] { "PacienteID" });
            DropTable("dbo.HistorialMedicoes");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Doctors");
            DropTable("dbo.CitaMedicas");
        }
    }
}
