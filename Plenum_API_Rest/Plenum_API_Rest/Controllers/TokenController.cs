using Plenum_API_Rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Plenum_API_Rest.Controllers
{
    public class TokenController : ApiController
    {
        public bool VerifyToken(string token)
        {
            using (ApplicationDbContext  db = new ApplicationDbContext()) {
                if(db.usuario.Where(x => x.token == token).Count() > 0)
                {
                    return true;

                }
            }
            return false;
        }
    }
}
