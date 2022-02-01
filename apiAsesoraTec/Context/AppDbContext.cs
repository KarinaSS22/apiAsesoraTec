using apiAsesoraTec.Models;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Sexo> sexo { get; set; }

        public DbSet<Usuario> usuario { get; set; }

        public DbSet<Titulo> titulo { get; set; }

        public DbSet<Asesor> asesor { get; set; }

        public DbSet<Administrador> administrador { get; set; }

        public DbSet<Semestre> semestre { get; set; }
        
        public DbSet<Carrera> carrera { get; set; }

        public DbSet<NombreEspe> nombreEspe { get; set; }

        public DbSet<Especialidad> especialidad { get; set; }

        public DbSet<Alumno> alumno { get; set; }

        public DbSet<NombreMat> nombreMat { get; set; }

        public DbSet<Creditos> creditos { get; set; }

        public DbSet<Materia> materia { get; set; }

        public DbSet<Departamento> departamento { get; set; }

        public DbSet<Calificacion> calificacion { get; set; }

        public DbSet<ModoImpa> modoImpa { get; set; }

        public DbSet<Ase_Carre> aseCarre { get; set; }

        public DbSet<Mat_Espe> matEspe { get; set; }

        public DbSet<Mat_Carre> matCarre { get; set; }

        public DbSet<Ase_Mat> aseMat { get; set; }

        public DbSet<Asesoria> asesoria { get; set; }

    }

}
