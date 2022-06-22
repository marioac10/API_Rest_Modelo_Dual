namespace Plenum_API_Rest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDatabaseAPI : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.actividad_alumno",
                c => new
                    {
                        id_alumno = c.Int(nullable: false),
                        id_tema = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id_alumno, t.id_tema })
                .ForeignKey("dbo.alumno", t => t.id_alumno, cascadeDelete: true)
                .ForeignKey("dbo.tema_unidad", t => t.id_tema, cascadeDelete: true)
                .Index(t => t.id_alumno)
                .Index(t => t.id_tema);
            
            CreateTable(
                "dbo.alumno",
                c => new
                    {
                        id_alumno = c.Int(nullable: false, identity: true),
                        matricula = c.String(nullable: false, maxLength: 50),
                        nombre = c.String(nullable: false, maxLength: 50),
                        apellido_p = c.String(nullable: false, maxLength: 50),
                        apellido_m = c.String(nullable: false, maxLength: 50),
                        telefono = c.String(nullable: false, maxLength: 10),
                        correo = c.String(nullable: false, maxLength: 60),
                        carrera = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id_alumno);
            
            CreateTable(
                "dbo.Alumno_Materia",
                c => new
                    {
                        id_alumno = c.Int(nullable: false),
                        id_materia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id_alumno, t.id_materia })
                .ForeignKey("dbo.alumno", t => t.id_alumno, cascadeDelete: true)
                .ForeignKey("dbo.materia", t => t.id_materia, cascadeDelete: true)
                .Index(t => t.id_alumno)
                .Index(t => t.id_materia);
            
            CreateTable(
                "dbo.materia",
                c => new
                    {
                        id_materia = c.Int(nullable: false, identity: true),
                        nombre_materia = c.String(nullable: false, maxLength: 50),
                        clave = c.String(nullable: false, maxLength: 50),
                        creditos = c.String(nullable: false, maxLength: 5),
                        semestre = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.id_materia);
            
            CreateTable(
                "dbo.tema_unidad",
                c => new
                    {
                        id_tema = c.Int(nullable: false, identity: true),
                        nombre_tema = c.String(nullable: false, maxLength: 50),
                        entregable = c.String(nullable: false, maxLength: 50),
                        unidad_id_unidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_tema)
                .ForeignKey("dbo.unidad_aprendizaje", t => t.unidad_id_unidad, cascadeDelete: true)
                .Index(t => t.unidad_id_unidad);
            
            CreateTable(
                "dbo.unidad_aprendizaje",
                c => new
                    {
                        id_unidad = c.Int(nullable: false, identity: true),
                        numero_unidad = c.String(nullable: false, maxLength: 5),
                        nombre_unidad = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id_unidad);
            
            CreateTable(
                "dbo.usuario",
                c => new
                    {
                        id_usuario = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false, maxLength: 50),
                        contraseña = c.String(nullable: false, maxLength: 50),
                        token = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.id_usuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tema_unidad", "unidad_id_unidad", "dbo.unidad_aprendizaje");
            DropForeignKey("dbo.actividad_alumno", "id_tema", "dbo.tema_unidad");
            DropForeignKey("dbo.actividad_alumno", "id_alumno", "dbo.alumno");
            DropForeignKey("dbo.Alumno_Materia", "id_materia", "dbo.materia");
            DropForeignKey("dbo.Alumno_Materia", "id_alumno", "dbo.alumno");
            DropIndex("dbo.tema_unidad", new[] { "unidad_id_unidad" });
            DropIndex("dbo.Alumno_Materia", new[] { "id_materia" });
            DropIndex("dbo.Alumno_Materia", new[] { "id_alumno" });
            DropIndex("dbo.actividad_alumno", new[] { "id_tema" });
            DropIndex("dbo.actividad_alumno", new[] { "id_alumno" });
            DropTable("dbo.usuario");
            DropTable("dbo.unidad_aprendizaje");
            DropTable("dbo.tema_unidad");
            DropTable("dbo.materia");
            DropTable("dbo.Alumno_Materia");
            DropTable("dbo.alumno");
            DropTable("dbo.actividad_alumno");
        }
    }
}
