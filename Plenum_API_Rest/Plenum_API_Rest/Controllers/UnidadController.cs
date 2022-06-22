using Plenum_API_Rest.Models;
using Plenum_API_Rest.Models.Tables;
using Plenum_API_Rest.Models.ViewModels;
using Plenum_API_Rest.Models.WS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Plenum_API_Rest.Controllers
{
    public class UnidadController : ApiController
    {
        // GET: api/Unidad
        [HttpGet]
        public Reply GetUnidades()
        {
            Reply reply = new Reply();
            reply.Result = 0;

            try
            {
                using(ApplicationDbContext db = new ApplicationDbContext())
                {

                    var unidades = (from d in db.unidad_aprendizaje
                                   select new UnidadesViewM
                                   {
                                       id = d.id_unidad,
                                       numero = d.numero_unidad,
                                       nombre = d.nombre_unidad
                                       //photo = d.foto
                                       
                                   }).ToList();

                    reply.Data = unidades;
                    reply.Result = 1;
                    reply.Message = "Todas las unidades";
                }

            }catch (Exception ex)
            {
                reply.Message = "Ha ocurrido un error";
            }
            return reply;
        }

        // GET: api/Unidad/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]

        public Reply PostUni([FromBody]UnidadesViewM unidad)
        {
            Reply reply = new Reply();
            reply.Result = 0;

            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var uni = new unidad_aprendizaje();
                    uni.numero_unidad = unidad.numero;
                    uni.nombre_unidad = unidad.nombre;
                    db.unidad_aprendizaje.Add(uni);
                    db.SaveChanges();
                    reply.Result = 1;
                    reply.Message = "Unidad registrada con éxito";
                }

            }catch (Exception ex)
            {
                reply.Message = "Ha ocurrido un error";
            }
            return reply;
        }

        // POST: api/Unidad
        [HttpPost]
        public async Task<Reply> PostUnidad([FromUri] UnidadViewModel unidad)
        {
            Reply reply = new Reply();
            reply.Result = 0;

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            //Validacion si viene un Multipart
            if (!Request.Content.IsMimeMultipartContent())
            {
                reply.Message = "No viene imagen";
                return reply;
            }
            
            await Request.Content.ReadAsMultipartAsync(provider);

            FileInfo fileInfoPicture = null;
            foreach (MultipartFileData fileData in provider.FileData) {
                if (fileData.Headers.ContentDisposition.Name.Replace("\\","").Replace("\"","").Equals("picture"))
                {
                    fileInfoPicture = new FileInfo(fileData.LocalFileName);
                }
            }

            if (fileInfoPicture != null) {
                using (FileStream fs = fileInfoPicture.Open(FileMode.Open,FileAccess.Read))
                {
                    byte[] picture = new byte[fileInfoPicture.Length];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs.Read(picture,0,picture.Length) > 0);

                    try
                    {
                        using (ApplicationDbContext db = new ApplicationDbContext()) {
                            
                            var uni = db.unidad_aprendizaje.Find(unidad.id_unidad);
                            uni.foto = picture;

                            db.Entry(uni).State  = System.Data.Entity.EntityState.Modified;
                            
                            //db.unidad_aprendizaje.Add(uni);
                            db.SaveChanges();
                            reply.Result = 1;
                            reply.Message = "Unidad registrada con éxito";
                        }


                    }catch(Exception ex) {
                        reply.Message = "Ha ocurrido un error";
                    }


                }
            }

            return reply;
        }

        // PUT: api/Unidad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Unidad/5
        public void Delete(int id)
        {
        }
    }
}
