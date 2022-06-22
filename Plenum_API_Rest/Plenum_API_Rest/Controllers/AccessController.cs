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
    public class AccessController : ApiController
    {
        // GET: api/Access
        [HttpGet]
        public Reply GetUsers()
        {
            Reply reply = new Reply();
            reply.Result = 0;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try {
                    var usersAll = db.usuario.ToList();
                    reply.Data = usersAll;
                    reply.Result = 1;
                    reply.Message = "Todos los usurios";

                }
                catch(Exception ex){
                    reply.Message = "Ha ocurrido un error";
                }     
            }

            return reply;
        }

        // GET: api/Access/5
        [HttpGet]
        public Reply GetId(int id)
        {
            Reply reply = new Reply();
            reply.Result = 0;
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var user = db.usuario.Where(x => x.id_usuario == id).FirstOrDefault();
                    if (user == null)
                    {
                        reply.Message = "Usuario no encontrado";
                    }
                    else
                    {
                        reply.Result = 1;
                        reply.Data = user;
                        reply.Message = "Usuario encontrado";
                    }
                }

            }
            catch (Exception ex) {
                reply.Message = "Ha ocurrido un error";
            }

            return reply;
        }

        // POST: api/Access
        [HttpPost]
        public Reply PostUser([FromBody] user user)
        {
            Reply reply= new Reply();
            reply.Result = 0;
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var usuarios = db.usuario.Where(x => x.email == user.email && x.contraseña == user.contraseña);

                    if (usuarios.Count() > 0)
                    {
                        reply.Message = "El usuario ya existe";

                    }
                    else
                    {   
                        reply.Result = 1;
                        reply.Data = Guid.NewGuid().ToString();

                        usuario u = new usuario();
                        u.email = user.email;
                        u.contraseña = user.contraseña;
                        u.token = (string)reply.Data;

                        //db.Entry(u).State = System.Data.Entity.EntityState.Modified;

                        db.usuario.Add(u);
                        db.SaveChanges();

                        reply.Message = "Usuario ingresado con éxito";
                    }
                }

            }
            catch (Exception ex) {
                reply.Message = "Ocurrió un error al ingresar el usuario";
            }

            return reply;
        }

        // PUT: api/Access/5
        /*public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Access/5
        public void Delete(int id)
        {
        }*/
    }
}
