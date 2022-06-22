using Plenum_API_Rest.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext():
            base("DefaultConnection")
        {

        }

        public DbSet<actividad_alumno> actividad_alumno { get; set; }
        public DbSet<alumno> alumno { get; set; }
        public DbSet<Alumno_Materia> alumno_materia { get; set; }
        public DbSet<materia> materia { get; set; }
        public DbSet<tema_unidad> tema_unidad { get; set; }
        //public DbSet<tipo_usuario> tipo_usuario { get; set; }
        public DbSet<unidad_aprendizaje> unidad_aprendizaje { get; set; }
        public DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Todo tema se relaciona con una unidad, no siempre una unidad tiene tema
            modelBuilder.Entity<tema_unidad>().HasRequired(x => x.unidad);

            //Todo usuario se relaciona con un rol, no siempre un rol tiene un usuario
            //modelBuilder.Entity<usuario>().HasRequired(x => x.tipo_usuario);

            modelBuilder.Entity<Alumno_Materia>().HasKey(x => new { x.id_alumno, x.id_materia });

            modelBuilder.Entity<actividad_alumno>().HasKey(x => new { x.id_alumno, x.id_tema });

            modelBuilder.Entity<unidad_aprendizaje>().Property(x => x.foto).HasColumnType("varbinary(MAX)");

            base.OnModelCreating(modelBuilder);
        }



    }
}