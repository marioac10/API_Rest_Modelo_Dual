using Plenum_API_Rest.Models;
using Plenum_API_Rest.Models.Tables;
using Plenum_API_Rest.Models.ViewModels;
using Plenum_API_Rest.Models.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Plenum_API_Rest.Controllers
{
    public class AlumnoController : TokenController
    {
        // GET: api/Alumno
        [HttpPost]
        public Reply GetAlumnos([FromBody] TokenViewModel model)
        {
            Reply reply = new Reply();
            reply.Result = 0;
            reply.Message = "Usuario no autorizado";


            if (!(VerifyToken(model.token))) {
                return reply;
            }
            
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var alumnos = (from d in db.alumno
                             select new AlumnoViewModel
                             {
                                 matricula = d.matricula,
                                 nombre = d.nombre,
                                 apellido_p = d.apellido_p,
                                 apellido_m = d.apellido_m,
                                 telefono = d.telefono,
                                 correo = d.correo,
                                 carrera = d.carrera
                             }).ToList();
                reply.Data = alumnos;
                reply.Message = "Todos los alumnos";
                reply.Result = 1;
            }

            return reply;
        }

        // GET: api/Alumno/5
        [HttpGet]
        public Reply GetAlumno(int id)
        {
            Reply reply = new Reply();
            reply.Result = 0;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                 var alum = db.alumno.Find(id);
                if (alum == null)
                {
                    reply.Message = "El alumno no existe";
                }
                else
                {
                    AlumnoViewModel model = new AlumnoViewModel();
                    model.matricula = alum.matricula;
                    model.nombre = alum.nombre;
                    model.apellido_p = alum.apellido_p;
                    model.apellido_m = alum.apellido_m;
                    model.telefono = alum.telefono;
                    model.correo = alum.correo;
                    model.carrera = alum.carrera;

                    reply.Result = 1;
                    reply.Data = model;
                    reply.Message = "Alumno encontrado";
                    
                }
            }
            return reply;
        }

        // POST: api/Alumno
        [HttpPost]
        public Reply PostAlumno([FromBody] AlumnoViewModel alum)
        {
            Reply reply = new Reply();
            reply.Result = 0;

            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    alumno a = new alumno();
                    a.matricula = alum.matricula;
                    a.nombre = alum.nombre;
                    a.apellido_p = alum.apellido_p;
                    a.apellido_m = alum.apellido_m;
                    a.telefono = alum.telefono;
                    a.correo = alum.correo;
                    a.carrera = alum.carrera;

                    db.alumno.Add(a);
                    db.SaveChanges();

                    reply.Result = 1;
                    reply.Message = "Alumno agregado con éxito";

                }

            }
            catch (Exception ex)
            {
                reply.Message = "Ha ocurrido un error";

            }
            return reply;
        }

        // PUT: api/Alumno/5
        [HttpPut]
        public Reply PutAlumno(int id, [FromBody]AlumnoViewModel alum)
        {
            Reply reply = new Reply();
            reply.Result = 0;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                alumno a = new alumno();
                a.id_alumno = id;
                a.matricula = alum.matricula;
                a.nombre = alum.nombre;
                a.apellido_p = alum.apellido_p;
                a.apellido_m = alum.apellido_m;
                a.telefono = alum.telefono;
                a.correo = alum.correo;
                a.carrera = alum.carrera;

                db.Entry(a).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                reply.Message = "Alumno modificado con éxito";
                reply.Result = 1;
            }

            return reply;
        }

        // DELETE: api/Alumno/5
        [HttpDelete]
        public Reply DeleteAlumno(int id)
        {
            Reply reply=new Reply();
            reply.Result=0;
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext()) {
                    var alum = db.alumno.Find(id);
                    db.alumno.Remove(alum);
                    db.SaveChanges();
                    reply.Message = "Alumno eliminado";  
                }

            }catch (Exception ex)
            {
                reply.Message = "Ha ocurrido un error";
            }
            return reply;
        }
    }
}
